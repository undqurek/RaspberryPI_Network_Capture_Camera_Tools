using RPiCapture.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
		private int _port = 5000;

		private RPiCameraClient _leftCamera = new RPiCameraClient();
		private RPiCameraClient _rightCamera = new RPiCameraClient();

		private Thread _leftTimer = null;
		private Object _leftLocker = new Object(); //TODO: bezpieczny dostep z wielu watkow

		private bool _leftLooped = false;
		private bool _leftStarted = false;

		private Thread _rightTimer = null;
		private Object _rightLocker = new Object(); //TODO: bezpieczny dostep z wielu watkow

		private bool _rightLooped = false;
		private bool _rightStarted = false;

		private bool _progress = false;
		private Dictionary<string, object> _leftResolutions;
		private Dictionary<string, object> _rightResolutions;

		public MainForm()
		{
			this.InitializeComponent();

			object[] leftItems = new object[]
			{
				new Resolution(2592, 1944),
				new Resolution(1920, 1080),
				new Resolution(1280, 960) 
			};

			object[] rightItems = new object[]
			{
				new Resolution(2592, 1944),
				new Resolution(1920, 1080),
				new Resolution(1280, 960) 
			};

			this._leftResolutions = new Dictionary<string, object>();
			this._rightResolutions = new Dictionary<string, object>();

			foreach (object el in leftItems)
				this._leftResolutions.Add(el.ToString(), el);

			foreach (object el in rightItems)
				this._rightResolutions.Add(el.ToString(), el);

			this.cbxLeftCameraResolution.DataSource = leftItems;
			this.cbxRightCameraResolution.DataSource = rightItems;
		}

		#region Helper methods

		#region Left camera modes

		private void SetLeftCameraConnectedMode()
		{
			this.txtLeftCameraHost.Enabled = false;
			this.btnLeftCameraConnectDisconnect.Text = "Disconnect (Left)";
			this.btnLeftCameraEnableDisable.Enabled = true;
			this.pnlLeftCamera.Enabled = true;

			string key = this._leftCamera.Width + "x" + this._leftCamera.Height;
			object value = null;

			if (this._leftResolutions.TryGetValue(key, out value))
			{
				this._progress = true;
				this.cbxLeftCameraResolution.SelectedItem = value;
				this._progress = false;
			}
		}

		private void SetLeftCameraDisconnectedMode()
		{
			this.txtLeftCameraHost.Enabled = true;
			this.btnLeftCameraConnectDisconnect.Text = "Connect (Left)";
			this.btnLeftCameraEnableDisable.Enabled = false;
			this.pnlLeftCamera.Enabled = false;
		}

		private void SetLeftCameraEnabledMode()
		{
			this.btnLeftCameraEnableDisable.Text = "Disable (Left)";

			this.cbxLeftCameraResolution.Enabled = false;
			this.btnLeftCameraCapture.Enabled = true;
			this.btnLeftCameraAutoCapture.Enabled = true;
		}

		private void SetLeftCameraDisabledMode()
		{
			this.btnLeftCameraEnableDisable.Text = "Enable (Left)";

			this.cbxLeftCameraResolution.Enabled = true;
			this.btnLeftCameraCapture.Enabled = false;
			this.btnLeftCameraAutoCapture.Enabled = false;
		}

		#endregion

		#region Right camera mode

		private void SetRightCameraConnectedMode()
		{
			this.txtRightCameraHost.Enabled = false;
			this.btnRightCameraConnectDisconnect.Text = "Disconnect (Right)";
			this.btnRightCameraEnableDisable.Enabled = true;
			this.pnlRightCamera.Enabled = true;

			string key = this._rightCamera.Width + "x" + this._rightCamera.Height;
			object value = null;

			if (this._rightResolutions.TryGetValue(key, out value))
			{
				this._progress = true;
				this.cbxRightCameraResolution.SelectedItem = value;
				this._progress = false;
			}
		}

		private void SetRightCameraDisconnectedMode()
		{
			this.txtRightCameraHost.Enabled = true;
			this.btnRightCameraConnectDisconnect.Text = "Connect (Right)";
			this.btnRightCameraEnableDisable.Enabled = false;
			this.pnlRightCamera.Enabled = false;
		}

		private void SetRightCameraEnabledMode()
		{
			this.btnRightCameraEnableDisable.Text = "Disable (Right)";

			this.cbxRightCameraResolution.Enabled = false;
			this.btnRightCameraCapture.Enabled = true;
			this.btnRightCameraAutoCapture.Enabled = true;
		}

		private void SetRightCameraDisabledMode()
		{
			this.btnRightCameraEnableDisable.Text = "Enable (Right)";

			this.cbxRightCameraResolution.Enabled = true;
			this.btnRightCameraCapture.Enabled = false;
			this.btnRightCameraAutoCapture.Enabled = false;
		}

		#endregion

		private void ConnectCamera(string side, RPiCameraClient camera, string host, Action connectAction, Action enableAction, Action disabletAction)
		{
			if (camera.Connect(host, this._port))
			{
				connectAction.Invoke();

				if (camera.Enabled)
					enableAction.Invoke();

				else
					disabletAction.Invoke();
			}
			else
				MessageBox.Show(side + " camera connection error!");
		}

		private void DisconnectCamera(RPiCameraClient camera, Action disconnectAction)
		{
			if (camera.Disconnect())
				disconnectAction.Invoke();
		}

		private void ConnectDisconnectCamera(string side, RPiCameraClient camera, string host, Action connectAction, Action disconnectAction, Action enableAction, Action disabletAction)
		{
			if (camera.Connected)
				this.DisconnectCamera(camera, disconnectAction);

			else
				this.ConnectCamera(side, camera, host, connectAction, enableAction, disabletAction);
		}

		private void EnableCamera(RPiCameraClient camera, Action enableAction)
		{
			if (camera.Enable())
				enableAction.Invoke();
		}

		private void DisableCamera(RPiCameraClient camera, Action disabletActione)
		{
			if (camera.Disable())
				disabletActione.Invoke();
		}

		private void EnableDisableCamera(RPiCameraClient camera, Action enableAction, Action disabletAction)
		{
			if (camera.Enabled)
				this.DisableCamera(camera, disabletAction);

			else
				this.EnableCamera(camera, enableAction);
		}

		private void CaptureCamera(RPiCameraClient camera, string side, NumericUpDown nudCameraRotation, NumericUpDown nudCameraXShift, NumericUpDown nudCameraYShift, PictureBox picCamera, DateTime now)
		{
			Image image = camera.Capture();

			if (image == null)
				return;

			unsafe
			{
				fixed (byte* pointer = image.Data)
				{
					int length = image.Height * image.Width * 3;

					for (int i = 0; i < length; i += 3)
					{
						byte tmp = pointer[i];

						pointer[i] = pointer[i + 2];
						pointer[i + 2] = tmp;
					}

					Bitmap source = new Bitmap(image.Width, image.Height, image.Width * 3, PixelFormat.Format24bppRgb, new IntPtr(pointer));
					Bitmap destination = new Bitmap(image.Width, image.Height);

					source.Save(now.Hour + "." + now.Minute + "." + now.Second + "." + now.Millisecond + "_" + side + "_camera_v1.png");
					
					int centerX = source.Width / 2;
					int centerY = source.Height / 2;

					using (Graphics g = Graphics.FromImage(destination))
					{
						g.Clear(Color.White);

						float rotation = 0.0f;
						float xShift = 0.0f;
						float yShift = 0.0f;

						this.Invoke(new Action(() =>
						{
							rotation = (float)nudCameraRotation.Value;
							xShift = (float)nudCameraXShift.Value;
							yShift = (float)nudCameraYShift.Value;
						}));

						GraphicsState state = g.Save();

						g.TranslateTransform(centerX + xShift, centerY + yShift);
						g.RotateTransform(rotation);
						g.TranslateTransform(-centerX, -centerY);
						g.DrawImage(source, 0.0f, 0.0f);

						g.Restore(state);

						destination.Save(now.Hour + "." + now.Minute + "." + now.Second + "." + now.Millisecond + "_" + side + "_camera_v2.png");
						
						g.DrawLine(Pens.Red, centerX, 0, centerX, source.Height); // pionowa
						g.DrawLine(Pens.Red, 0, centerY, source.Width, centerY); // pozioma

						destination.Save(now.Hour + "." + now.Minute + "." + now.Second + "." + now.Millisecond + "_" + side + "_camera_v3.png");
					}

					picCamera.Image = destination;
				}
			}
		}

		private void MakeCapture(Object locker, RPiCameraClient camera, ref bool started, ref bool looped, Button btnCameraCapture, Button btnCameraAutoCapture, NumericUpDown nudCameraRotation, NumericUpDown nudCameraXShift, NumericUpDown nudCameraYShift, PictureBox picCamera)
		{
			this.Invoke(new Action(() =>
			{
				btnCameraCapture.Enabled = false;

				btnCameraAutoCapture.Text = "Auto capture (Enabled)";
				btnCameraAutoCapture.Enabled = true;
			}));

			started = true;

			while (looped)
			{
				Image image = null;

				lock (locker)
					image = camera.Capture();

				if (image == null)
					break;

				unsafe
				{
					fixed (byte* pointer = image.Data)
					{
						int length = image.Height * image.Width * 3;

						for (int i = 0; i < length; i += 3)
						{
							byte tmp = pointer[i];

							pointer[i] = pointer[i + 2];
							pointer[i + 2] = tmp;
						}

						Bitmap source = new Bitmap(image.Width, image.Height, image.Width * 3, PixelFormat.Format24bppRgb, new IntPtr(pointer));
						Bitmap destination = new Bitmap(image.Width, image.Height);

						int centerX = source.Width / 2;
						int centerY = source.Height / 2;

						using (Graphics g = Graphics.FromImage(destination))
						{
							g.Clear(Color.White);

							float rotation = 0.0f;
							float xShift = 0.0f;
							float yShift = 0.0f;

							this.Invoke(new Action(() =>
							{
								rotation = (float)nudCameraRotation.Value;
								xShift = (float)nudCameraXShift.Value;
								yShift = (float)nudCameraYShift.Value;
							}));

							GraphicsState state = g.Save();

							g.TranslateTransform(centerX + xShift, centerY + yShift);
							g.RotateTransform(rotation);
							g.TranslateTransform(-centerX, -centerY);
							g.DrawImage(source, 0.0f, 0.0f);

							g.Restore(state);

							g.DrawLine(Pens.Red, centerX, 0, centerX, source.Height); // pionowa
							g.DrawLine(Pens.Red, 0, centerY, source.Width, centerY); // pozioma
						}

						this.Invoke(new Action(() =>
						{
							System.Drawing.Image tmp = picCamera.Image;

							if (tmp != null)
								tmp.Dispose();

							picCamera.Image = destination;
						}));
					}
				}
			}

			this.Invoke(new Action(() =>
			{
				btnCameraCapture.Enabled = true;

				btnCameraAutoCapture.Text = "Auto capture (Disabled)";
				btnCameraAutoCapture.Enabled = true;
			}));

			started = false;
		}

		#endregion

		#region Event methods
		
		private void MainForm_Load(object sender, EventArgs e)
		{
			this.txtLeftCameraHost.Text = Settings.Default.LEFT_CAMERA_HOST;
			this.txtRightCameraHost.Text = Settings.Default.RIGHT_CAMERA_HOST;

			this.nudLeftCameraRotation.Value = Settings.Default.LEFT_CAMERA_ROTATION;
			this.nudLeftCameraXShift.Value = Settings.Default.LEFT_CAMERA_X_SHIFT;
			this.nudLeftCameraYShift.Value = Settings.Default.LEFT_CAMERA_Y_SHIFT;

			this.nudRightCameraRotation.Value = Settings.Default.RIGHT_CAMERA_ROTATION;
			this.nudRightCameraXShift.Value = Settings.Default.RIGHT_CAMERA_X_SHIFT;
			this.nudRightCameraYShift.Value = Settings.Default.RIGHT_CAMERA_Y_SHIFT;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this._leftCamera.Disconnect();
			this._rightCamera.Disconnect();

			//TODO: przerwanie watkow
		}

		private void txtLeftCameraHost_Leave(object sender, EventArgs e)
		{
			Settings.Default.LEFT_CAMERA_HOST = this.txtLeftCameraHost.Text;

			Settings.Default.Save();
		}

		private void txtRightCameraHost_Leave(object sender, EventArgs e)
		{
			Settings.Default.RIGHT_CAMERA_HOST = this.txtRightCameraHost.Text;

			Settings.Default.Save();
		}

		private void nudLeftCameraRotation_Leave(object sender, EventArgs e)
		{
			Settings.Default.LEFT_CAMERA_ROTATION = this.nudLeftCameraRotation.Value;

			Settings.Default.Save();
		}

		private void nudLeftCameraXShift_Leave(object sender, EventArgs e)
		{
			Settings.Default.LEFT_CAMERA_X_SHIFT = this.nudLeftCameraXShift.Value;

			Settings.Default.Save();
		}

		private void nudLeftCameraYShift_Leave(object sender, EventArgs e)
		{
			Settings.Default.LEFT_CAMERA_Y_SHIFT = this.nudLeftCameraYShift.Value;

			Settings.Default.Save();
		}

		private void nudRightCameraRotation_Leave(object sender, EventArgs e)
		{
			Settings.Default.RIGHT_CAMERA_ROTATION = this.nudRightCameraRotation.Value;

			Settings.Default.Save();
		}

		private void nudRightCameraXShift_Leave(object sender, EventArgs e)
		{
			Settings.Default.RIGHT_CAMERA_X_SHIFT = this.nudRightCameraXShift.Value;

			Settings.Default.Save();
		}

		private void nudRightCameraYShift_Leave(object sender, EventArgs e)
		{
			Settings.Default.RIGHT_CAMERA_Y_SHIFT = this.nudRightCameraYShift.Value;

			Settings.Default.Save();
		}

		private void btnCamerasConnect_Click(object sender, EventArgs e)
		{
			this.ConnectCamera("Left", this._leftCamera, this.txtLeftCameraHost.Text, this.SetLeftCameraConnectedMode, this.SetLeftCameraEnabledMode, this.SetLeftCameraDisabledMode);
			this.ConnectCamera("Right", this._rightCamera, this.txtRightCameraHost.Text, this.SetRightCameraConnectedMode, this.SetRightCameraEnabledMode, this.SetRightCameraDisabledMode);
		}

		private void btnCamerasDisconnect_Click(object sender, EventArgs e)
		{
			this.DisconnectCamera(this._leftCamera, this.SetLeftCameraDisconnectedMode);
			this.DisconnectCamera(this._rightCamera, this.SetRightCameraDisconnectedMode);
		}

		private void btnCamerasEnable_Click(object sender, EventArgs e)
		{
			this.EnableCamera(this._leftCamera, this.SetLeftCameraEnabledMode);
			this.EnableCamera(this._rightCamera, this.SetRightCameraEnabledMode);
		}

		private void btnCamerasDisable_Click(object sender, EventArgs e)
		{
			this.DisableCamera(this._leftCamera, this.SetLeftCameraDisabledMode);
			this.DisableCamera(this._rightCamera, this.SetRightCameraDisabledMode);
		}

		private void btnCamerasCapture_Click(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;

			this.CaptureCamera(this._leftCamera, "left", this.nudLeftCameraRotation, this.nudLeftCameraXShift, this.nudLeftCameraYShift, this.picLeftCamera, now);
			this.CaptureCamera(this._rightCamera, "right", this.nudRightCameraRotation, this.nudRightCameraXShift, this.nudRightCameraYShift, this.picRightCamera, now);
		}

		private void btnLeftCameraConnectDisconnect_Click(object sender, EventArgs e)
		{
			this.ConnectDisconnectCamera("Left", this._leftCamera, this.txtLeftCameraHost.Text, this.SetLeftCameraConnectedMode, this.SetLeftCameraDisconnectedMode, this.SetLeftCameraEnabledMode, this.SetLeftCameraDisabledMode);
		}

		private void btnRightCameraConnectDisconnect_Click(object sender, EventArgs e)
		{
			this.ConnectDisconnectCamera("Right", this._rightCamera, this.txtRightCameraHost.Text, this.SetRightCameraConnectedMode, this.SetRightCameraDisconnectedMode, this.SetRightCameraEnabledMode, this.SetRightCameraDisabledMode);
		}

		private void btnLeftCameraEnableDisable_Click(object sender, EventArgs e)
		{
			this.EnableDisableCamera(this._leftCamera, this.SetLeftCameraEnabledMode, this.SetLeftCameraDisabledMode);
		}

		private void btnRightCameraEnableDisable_Click(object sender, EventArgs e)
		{
			this.EnableDisableCamera(this._rightCamera, this.SetRightCameraEnabledMode, this.SetRightCameraDisabledMode);
		}

		private void cbxLeftCameraResolution_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this._progress)
				return;

			Resolution resolution = this.cbxLeftCameraResolution.SelectedItem as Resolution;

			if (resolution == null)
				return;

			this._leftCamera.Resize(resolution.Width, resolution.Height);
		}

		private void cbxRightCameraResolution_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this._progress)
				return;

			Resolution resolution = this.cbxRightCameraResolution.SelectedItem as Resolution;

			if (resolution == null)
				return;

			this._rightCamera.Resize(resolution.Width, resolution.Height);
		}

		private void btnLeftCameraCapture_Click(object sender, EventArgs e)
		{
			this.CaptureCamera(this._leftCamera, "left", this.nudLeftCameraRotation, this.nudLeftCameraXShift, this.nudLeftCameraYShift, this.picLeftCamera, DateTime.Now);
		}

		private void btnRightCameraCapture_Click(object sender, EventArgs e)
		{
			this.CaptureCamera(this._rightCamera, "right", this.nudRightCameraRotation, this.nudRightCameraXShift, this.nudRightCameraYShift, this.picRightCamera, DateTime.Now);
		}

		private void btnLeftCameraAutoCapture_Click(object sender, EventArgs e)
		{
			this.btnLeftCameraAutoCapture.Enabled = false;

			if (this._leftStarted)
				this._leftLooped = false;

			else
			{
				this._leftLooped = true;

				this._leftTimer = new Thread(() => this.MakeCapture(this._leftLocker, this._leftCamera, ref this._leftStarted, ref this._leftLooped, this.btnLeftCameraCapture, this.btnLeftCameraAutoCapture, this.nudLeftCameraRotation, this.nudLeftCameraXShift, this.nudLeftCameraYShift, this.picLeftCamera));
				this._leftTimer.Start();
			}
		}

		private void btnRightCameraAutoCapture_Click(object sender, EventArgs e)
		{
			this.btnRightCameraAutoCapture.Enabled = false;

			if (this._rightStarted)
				this._rightLooped = false;

			else
			{
				this._rightLooped = true;

				this._rightTimer = new Thread(() => this.MakeCapture(this._rightLocker, this._rightCamera, ref this._rightStarted, ref this._rightLooped, this.btnRightCameraCapture, this.btnRightCameraAutoCapture, this.nudRightCameraRotation, this.nudRightCameraXShift, this.nudRightCameraYShift, this.picRightCamera));
				this._rightTimer.Start();
			}
		}

		#endregion

		#region Helper classes

		private class Resolution
		{
			public UInt16 Width { get; private set; }
			public UInt16 Height { get; private set; }

			public Resolution(UInt16 width, UInt16 height)
			{
				this.Width = width;
				this.Height = height;
			}

			public override string ToString()
			{
				return this.Width + "x" + this.Height;
			}
		}

		#endregion
	}
}
