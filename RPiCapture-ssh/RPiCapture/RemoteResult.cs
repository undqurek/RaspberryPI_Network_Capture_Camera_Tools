using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPiCapture
{
	public abstract class RemoteResult
	{
		/// <summary>
		/// Zwraca i ustawia relatywną ścieżkę do pliku z wynikiem.
		/// </summary>
		public abstract string Path { get; }

		/// <summary>
		/// Odbiera wskazane dane z serwera.
		/// </summary>
		/// <param name="sshClient"></param>
		/// <param name="sftpClient"></param>
		public abstract bool Receive(string workingPath, SshClient sshClient, SftpClient sftpClient);
	}

	public class DataRemoteResult : RemoteResult
	{
		private Action<byte[]> _callback;
		private string _path;

		public override string Path
		{
			get { return this._path; }
		}

		public DataRemoteResult(string path, Action<byte[]> callback)
		{
			this._callback = callback;
			this._path = path;
		}

		public override bool Receive(string workingPath, SshClient sshClient, SftpClient sftpClient)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				try
				{
					try
					{
						//HACK
						sftpClient.ChangeDirectory(workingPath);
					}
					catch (Exception)
					{

					}

					sftpClient.DownloadFile(this._path, stream);

					if (this._callback != null)
						this._callback.Invoke(stream.ToArray());

					return true;
				}
				finally
				{
					stream.Close();
				}
			}
		}
	}

	public class TextRemoteResult : RemoteResult
	{
		private Action<string> _callback;
		private string _path;

		public override string Path
		{
			get { return this._path; }
		}

		public TextRemoteResult(string path, Action<string> callback)
		{
			this._callback = callback;
			this._path = path;
		}

		public override bool Receive(string workingPath, SshClient sshClient, SftpClient sftpClient)
		{
			using (SshCommand command = sshClient.CreateCommand("cd \"" + workingPath + "\"; cat \"" + this._path + "\""))
			{
				string text = command.Execute();

				if (command.ExitStatus != 0)
					return false;

				this._callback.Invoke(text);
			}

			return true;
		}
	}

	public class FileRemoteResult : RemoteResult
	{
		private string _localPath;
		private string _remotePath;

		public override string Path
		{
			get { return this._remotePath; }
		}

		public FileRemoteResult(string localPath, string remotePath)
		{
			this._localPath = localPath;
			this._remotePath = remotePath;
		}

		public override bool Receive(string workingPath, SshClient sshClient, SftpClient sftpClient)
		{
			using (FileStream stream = new FileStream(this._localPath, FileMode.Create, FileAccess.Write))
			{
				try
				{
					sftpClient.ChangeDirectory(workingPath);
					sftpClient.DownloadFile(this._remotePath, stream);

					return true;
				}
				finally
				{
					stream.Close();
				}
			}
		}
	}
}
