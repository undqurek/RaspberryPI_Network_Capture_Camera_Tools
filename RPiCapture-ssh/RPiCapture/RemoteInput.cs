using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RPiCapture
{
	public abstract class RemoteInput
	{
		/// <summary>
		/// Zwraca i ustawia relatywną ścieżkę do pliku z wynikiem.
		/// </summary>
		public abstract string Path { get; }

		/// <summary>
		/// Wysyla wskazane dane na serwer.
		/// </summary>
		/// <param name="sshClient"></param>
		/// <param name="sftpClient"></param>
		public abstract bool Send(string workingPath, SshClient sshClient, SftpClient sftpClient);
	}

	public class DataRemoteInput : RemoteInput
	{
		private byte[] _data;
		private string _path;

		public override string Path 
		{
			get { return this._path; }
		}

		public DataRemoteInput(byte[] data, string path)
		{
			this._data = data;
			this._path = path;
		}

		public override bool Send(string workingPath, SshClient sshClient, SftpClient sftpClient)
		{
			using(MemoryStream stream = new MemoryStream(this._data))
			{
				try
				{
					sftpClient.ChangeDirectory(workingPath);
					sftpClient.UploadFile(stream, this._path);

					return true;
				}
				catch (Exception)
				{
					return false;
				}
				finally
				{
					stream.Close();
				}
			}
		}
	}

	public class TextRemoteInput : RemoteInput
	{
		private string _data;
		private string _path;

		public override string Path
		{
			get { return this._path; }
		}

		public TextRemoteInput(string data, string path)
		{
			this._data = data;
			this._path = path;
		}

		public override bool Send(string workingPath, SshClient sshClient, SftpClient sftpClient)
		{
			string data = this._data.Replace("\"", "\\\"");

			using (SshCommand command = sshClient.CreateCommand("cd \"" + workingPath + "\"; echo \"" + data + "\" > \"" + this._path + "\""))
			{
				command.Execute();

				if (command.ExitStatus == 0)
					return true;
			}

			return false;
		}
	}

	public class FileRemoteInput : RemoteInput
	{
		private string _localPath;
		private string _remotePath;

		public override string Path
		{
			get { return this._remotePath; }
		}

		public FileRemoteInput(string localPath, string remotePath)
		{
			this._localPath = localPath;
			this._remotePath = remotePath;
		}

		public override bool Send(string workingPath, SshClient sshClient, SftpClient sftpClient)
		{
			using (FileStream stream = new FileStream(this._localPath, FileMode.Open, FileAccess.Read))
			{
				try
				{
					sftpClient.ChangeDirectory(workingPath); 
					sftpClient.UploadFile(stream, this._remotePath);

					return true;
				}
				catch (Exception)
				{
					return false;
				}
				finally
				{
					stream.Close();
				}
			}
		}
	}
}
