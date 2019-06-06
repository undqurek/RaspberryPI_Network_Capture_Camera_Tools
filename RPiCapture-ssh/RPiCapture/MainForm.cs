using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPiCapture
{
	public partial class MainForm : Form
	{
		private RemoteSolver _leftCamera = new RemoteSolver();
		private RemoteSolver _rightCamera = new RemoteSolver();

		private bool _locked = true;

		public MainForm()
		{
			this.InitializeComponent();

			this._leftCamera.Host = "192.168.1.162";
			this._leftCamera.Port = 22;
			this._leftCamera.Username = "pi";
			this._leftCamera.Password = "pi12345";

			this._rightCamera.Host = "192.168.1.101";
			this._rightCamera.Port = 22;
			this._rightCamera.Username = "pi";
			this._rightCamera.Password = "pi12345";

			Thread t = new Thread(() =>
			{
				bool result = true;

				try
				{
					this.Invoke(new Action(() => this.Text = "Camera 1 is connecting..."));
					this._leftCamera.Connect();
				}
				catch (Exception)
				{
					MessageBox.Show("Left camera connection problem!");

					result = false;
				}

				try
				{
					this.Invoke(new Action(() => this.Text = "Camera 2 is connecting..."));
					this._rightCamera.Connect();
				}
				catch (Exception)
				{
					MessageBox.Show("Right camera connection problem!");

					result = false;
				}

				if (result)
				{
					this.Invoke(new Action(() => this.Text = "Cameras connected!"));
					this._locked = false;
				}
			});

			t.Start();
		}

		private void btnCameraCapture_Click(object sender, EventArgs e)
		{
			if (this._locked)
				return;

			DateTime now = DateTime.Now;

			Thread t1 = new Thread(() =>
			{
				while (true)
				{
					Action<byte[]> callback = (data) =>
					{
						using (MemoryStream stream = new MemoryStream(data))
						{
							Bitmap bitmap1 = new Bitmap(stream);
							Bitmap bitmap2 = (Bitmap)bitmap1.Clone();

							using (Graphics g = Graphics.FromImage(bitmap1))
							{
								g.DrawLine(Pens.Red, bitmap1.Width / 2, 0, bitmap1.Width / 2, bitmap1.Height); // pionowa
								g.DrawLine(Pens.Red, 0, bitmap1.Height / 2, bitmap1.Width, bitmap1.Height / 2); // pozioma
							}

							bitmap1.Save("left_camera_" + now.Hour + "." + now.Minute + "." + now.Second + "." + now.Millisecond + "_v1.png");
							bitmap2.Save("left_camera_" + now.Hour + "." + now.Minute + "." + now.Second + "." + now.Millisecond + "_v2.png");

							this.Invoke(new Action(() => this.picLeftCamera.Image = bitmap1));
						}
					};

					ProcessRemoteTask task = new ProcessRemoteTask("raspistill -rot 270 -vf -hf -o camera.jpg");
					RemoteResult result = new DataRemoteResult("camera.jpg", callback);

					this._leftCamera.Execute(task, null, result);
				}
			});

			Thread t2 = new Thread(() =>
			{
				while (true)
				{
					Action<byte[]> callback = (data) =>
					{
						using (MemoryStream stream = new MemoryStream(data))
						{
							Bitmap bitmap1 = new Bitmap(stream);
							Bitmap bitmap2 = (Bitmap)bitmap1.Clone();

							using (Graphics g = Graphics.FromImage(bitmap1))
							{
								g.DrawLine(Pens.Red, bitmap1.Width / 2, 0, bitmap1.Width / 2, bitmap1.Height); // pionowa
								g.DrawLine(Pens.Red, 0, bitmap1.Height / 2, bitmap1.Width, bitmap1.Height / 2); // pozioma
							}

							bitmap1.Save("right_camera_" + now.Hour + "." + now.Minute + "." + now.Second + "." + now.Millisecond + "_v1.png");
							bitmap2.Save("right_camera_" + now.Hour + "." + now.Minute + "." + now.Second + "." + now.Millisecond + "_v2.png");

							this.Invoke(new Action(() => this.picRightCamera.Image = bitmap1));
						}
					};

					ProcessRemoteTask task = new ProcessRemoteTask("raspistill -rot 90 -vf -hf -o camera.jpg");
					RemoteResult result = new DataRemoteResult("camera.jpg", callback);

					this._rightCamera.Execute(task, null, result);
				}
			});

			t1.Start();
			t2.Start();

			//t1.Join();
			//t2.Join();

			//MessageBox.Show("Ready!!!");
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this._leftCamera.Disconnect();
			this._rightCamera.Disconnect();
		}
	}
}
