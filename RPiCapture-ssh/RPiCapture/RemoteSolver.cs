using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPiCapture
{
	public class RemoteSolver
	{
		#region Variables

		private string _host = "149.156.112.111";
		private int _port = 22;

		private string _username = "pi";
		private string _password = "pi12345";

		private string _remotePath = "";
		private string _workspaceName = "workspace";
		private int _solverNumber = 1;

		private SshClient _sshClient;
		private SftpClient _sftpClient;

		#endregion

		#region Properties

		public string Host
		{
			get { return this._host; }

			set
			{
				if (this._sshClient != null)
					throw new Exception("Disconnect before any changes.");

				this._host = value;
			}
		}

		public int Port
		{
			get { return this._port; }

			set
			{
				if (this._sshClient != null)
					throw new Exception("Disconnect before any changes.");

				this._port = value;
			}
		}

		public string Username
		{
			get { return this._username; }

			set
			{
				if (this._sshClient != null)
					throw new Exception("Disconnect before any changes.");

				this._username = value;
			}
		}

		public string Password
		{
			get { return this._password; }

			set
			{
				if (this._sshClient != null)
					throw new Exception("Disconnect before any changes.");

				this._password = value;
			}
		}

		public string RemotePath
		{
			get { return this._remotePath; }

			set
			{
				if (this._sshClient != null)
					throw new Exception("Disconnect before any changes.");

				this._remotePath = value;
			}
		}

		public string WorkspaceName
		{
			get { return this._workspaceName; }

			set
			{
				if (this._sshClient != null)
					throw new Exception("Disconnect before any changes.");

				this._workspaceName = value;
			}
		}

		public int SolverNumber
		{
			get { return this._solverNumber; }

			set
			{
				if (this._sshClient != null)
					throw new Exception("Disconnect before any changes.");

				this._solverNumber = value;
			}
		}

		#endregion

		#region Public methods

		public void Connect()
		{
			if (this._sshClient != null)
				throw new Exception("Connection has already been established");

			AuthenticationMethod[] methods = new AuthenticationMethod[]
			{
				new PasswordAuthenticationMethod(this._username, this._password)
			};

			ConnectionInfo info = new ConnectionInfo(this._host, this._port, this._username, methods);

			try
			{
				this._sshClient = new SshClient(info);
				this._sftpClient = new SftpClient(info);

				this._sshClient.Connect();
				this._sftpClient.Connect();
			}
			catch (Exception ex)
			{
				if (this._sshClient != null)
				{
					this._sshClient.Dispose();
					this._sshClient = null;
				}

				if (this._sftpClient != null)
				{
					this._sftpClient.Dispose();
					this._sftpClient = null;
				}

				throw ex;
			}
		}

		public void Disconnect()
		{
			if (this._sshClient == null)
				return;

			this._sshClient.Disconnect();
			this._sshClient.Dispose();

			this._sshClient = null;
		}

		public bool Execute(RemoteTask[] tasks, RemoteInput[] inputs, RemoteResult[] results)
		{
			if (this._sshClient == null)
				return false;

			string path = this._remotePath + this._workspaceName + "/solver-" + this._solverNumber + "/";

			#region Working directory reset

			using (SshCommand command = this._sshClient.CreateCommand("rm -rf " + path + "; mkdir -p " + path))
			{
				command.Execute();

				if (command.ExitStatus != 0)
					return false;
			}

			#endregion

			#region Input data upload

			if (inputs != null)
			{
				foreach (RemoteInput el in inputs)
				{
					if (!el.Send(path, this._sshClient, this._sftpClient))
						return false;
				}
			}

			#endregion

			#region Tasks execution

			if (tasks != null)
			{
				foreach (RemoteTask el in tasks)
				{
					if (!el.Execute(path, this._sshClient))
						return false;
				}
			}

			#endregion

			#region Output data download

			if (results != null)
			{
				foreach (RemoteResult el in results)
				{
					if (!el.Receive(path, this._sshClient, this._sftpClient))
						return false;
				}
			}

			#endregion

			return true;
		}

		public bool Execute(RemoteTask task, RemoteInput input, RemoteResult result)
		{
			RemoteTask[] tasks = null;
			RemoteInput[] inputs = null;
			RemoteResult[] results = null;

			if (task != null)
			{
				tasks = new RemoteTask[]
				{
					task
				};
			}

			if (input != null)
			{
				inputs = new RemoteInput[]
				{
					input
				};
			}

			if (result != null)
			{
				results = new RemoteResult[]
				{
					result
				};
			}

			return this.Execute(tasks, inputs, results);
		}

		#endregion
	}
}
