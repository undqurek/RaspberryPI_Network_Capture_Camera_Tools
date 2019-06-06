using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RPiCapture
{
	public abstract class RemoteTask
	{
		/// <summary>
		/// Zwraca i ustawia relatywną ścieżkę do pliku z wynikiem.
		/// </summary>
		public abstract string Command { get; }

		public abstract bool Execute(string workingPath, SshClient client);
	}

	public class ShellRemoteTask : RemoteTask
	{
		private readonly Random _randomizer = new Random();

		private static readonly string[] _characters = new string[]
		{
			"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
			"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "w", "y", "x", "z",
			"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "W", "Y", "X", "Z",
		};

		private Action<string> _callback;
		private string _command;

		public override string Command
		{
			get { return this._command; }
		}

		public ShellRemoteTask(string command, Action<string> callback)
		{
			this._callback = callback;
			this._command = command;
		}

		private string GenerateMarker(int size = 30)
		{
			StringBuilder builder = new StringBuilder(size);

			for (int i = 0; i < size; ++i)
			{
				int index = this._randomizer.Next(_characters.Length);

				builder.Append(_characters[index]);
			}

			return builder.ToString();
		}

		public override bool Execute(string workingPath, SshClient client)
		{
			int capacity = 5 * 1024 * 1024; // terminal capacity

			string marker = this.GenerateMarker();
			string command = this._command + "; KEY_CODE=[" + marker + "]; echo \"END->${KEY_CODE}\""; //HACK

			ResponseExtractor extractor = new ResponseExtractor("$ " + command + "\r\n", "END->[" + marker + "]"); //HACK

			string result = null;

			using (ShellStream stream = client.CreateShellStream("solver", 237, 64, 237, 64, capacity))
			{
				stream.WriteLine("cd \"" + workingPath + "\"");
				stream.WriteLine(command);

				byte[] buffer = new byte[256];

				while (result == null)
				{
					int count = stream.Read(buffer, 0, buffer.Length);

					if (count > 0)
					{
						result = extractor.Analyze(buffer, count);

						if (result != null)
							break;
					}
					else
						Thread.Sleep(100);
				}

				stream.Close();
			}

			this._callback.Invoke(result);

			return true;
		}
	}

	public class ProcessRemoteTask : RemoteTask
	{
		private Action<string> _callback;
		private string _command;

		public override string Command
		{
			get { return this._command; }
		}

		public ProcessRemoteTask(string command, Action<string> callback)
		{
			this._callback = callback;
			this._command = command;
		}

		public ProcessRemoteTask(string command)
			: this(command, null)
		{
			
		}

		public override bool Execute(string workingPath, SshClient client)
		{
			using (SshCommand command = client.CreateCommand("cd \"" + workingPath + "\"; " + this._command))
			{
				string text = command.Execute();

				if (command.ExitStatus != 0)
					return false;

				if (this._callback != null)
					this._callback.Invoke(text);
			}

			return true;
		}
	}

	public class SequenceDetector
	{
		private int _offset = 0;
		private byte[] _data;

		public SequenceDetector(byte[] data)
		{
			this._data = data;
		}

		public SequenceDetector(string text)
		{
			this._data = Encoding.UTF8.GetBytes(text);
		}

		public int Detect(byte[] data, int offset, int limit)
		{
			if (limit > data.Length)
				limit = data.Length;

			for (int i = offset; i < limit; ++i)
			{
				if (this._offset < this._data.Length)
				{
					if (data[i] == this._data[this._offset])
					{
						this._offset += 1;

						if (this._offset == this._data.Length)
						{
							this._offset = 0;

							return i + 1;
						}
					}
					else
						this._offset = 0;
				}
				else
					return -1;
			}

			return -1;
		}
	}

	public class ResponseExtractor
	{
		//#region Const

		//private const int SOH = 1;
		//private const int ESC = 27;

		//private readonly byte[] _terminator = new byte[] { SOH, ESC };

		//#endregion

		#region Variables

		private StringBuilder _builder = new StringBuilder();

		private SequenceDetector _beginDetector;
		private SequenceDetector _endDetector;

		private Action<byte[], int> _currentAction = null;
		private int _protrusion = 0;

		#endregion

		public ResponseExtractor(string begin, string end)
		{
			this._beginDetector = new SequenceDetector(begin);
			this._endDetector = new SequenceDetector(end);

			this._currentAction = this.MakeAction1;
			this._protrusion = end.Length;
		}

		#region Helper methods

		private void AppendData(byte[] data)
		{
			this.AppendData(data, 0, data.Length);
		}

		private void AppendData(byte[] data, int offset, int count)
		{
			string text = Encoding.UTF8.GetString(data, offset, count);

			this._builder.Append(text);
		}

		private void MakeAction1(byte[] data, int count)
		{
			int offset = this._beginDetector.Detect(data, 0, count);

			if (offset > -1)
			{
				int limit = this._endDetector.Detect(data, offset, count);

				if (limit > -1)
				{
					if (offset < limit)
						this.AppendData(data, offset, limit - offset);

					this._currentAction = this.MakeAction3;
				}
				else
				{
					if (offset < data.Length)
						this.AppendData(data, offset, data.Length - offset);

					this._currentAction = this.MakeAction2;
				}
			}
		}

		private void MakeAction2(byte[] data, int count)
		{
			int offset = this._endDetector.Detect(data, 0, count);

			if (offset > -1)
			{
				if (offset > 1)
					this.AppendData(data, 0, offset);

				this._currentAction = this.MakeAction3;
			}
			else
				this.AppendData(data);
		}

		private void MakeAction3(byte[] data, int count)
		{
			//empty...
		}

		#endregion

		#region Public methods

		public string Analyze(byte[] data, int count)
		{
			string tmp22 = Encoding.UTF8.GetString(data, 0, count);

			if (this._currentAction == this.MakeAction3)
				return null;

			this._currentAction.Invoke(data, count);

			if (this._currentAction == this.MakeAction3)
			{
				String tmp = this._builder.ToString();

				if (tmp.Length > this._protrusion)
					return tmp.Substring(0, tmp.Length - this._protrusion);

				return String.Empty;
			}

			return null;
		}

		public string Analyze(byte[] data)
		{
			return this.Analyze(data, data.Length);
		}

		#endregion
	}
}
