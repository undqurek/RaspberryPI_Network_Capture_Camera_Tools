namespace RPiCapture
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.picLeftCamera = new System.Windows.Forms.PictureBox();
			this.picRightCamera = new System.Windows.Forms.PictureBox();
			this.btnCamerasConnect = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnLeftCameraConnectDisconnect = new System.Windows.Forms.Button();
			this.btnRightCameraConnectDisconnect = new System.Windows.Forms.Button();
			this.btnRightCameraEnableDisable = new System.Windows.Forms.Button();
			this.btnLeftCameraEnableDisable = new System.Windows.Forms.Button();
			this.btnCamerasEnable = new System.Windows.Forms.Button();
			this.btnRightCameraCapture = new System.Windows.Forms.Button();
			this.btnLeftCameraCapture = new System.Windows.Forms.Button();
			this.btnCamerasCapture = new System.Windows.Forms.Button();
			this.txtLeftCameraHost = new System.Windows.Forms.TextBox();
			this.txtRightCameraHost = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btnCamerasDisable = new System.Windows.Forms.Button();
			this.btnCamerasDisconnect = new System.Windows.Forms.Button();
			this.cbxLeftCameraResolution = new System.Windows.Forms.ComboBox();
			this.cbxRightCameraResolution = new System.Windows.Forms.ComboBox();
			this.btnLeftCameraAutoCapture = new System.Windows.Forms.Button();
			this.pnlLeftCamera = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.pnlRightCamera = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.btnRightCameraAutoCapture = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.nudLeftCameraRotation = new System.Windows.Forms.NumericUpDown();
			this.nudLeftCameraXShift = new System.Windows.Forms.NumericUpDown();
			this.nudLeftCameraYShift = new System.Windows.Forms.NumericUpDown();
			this.nudRightCameraYShift = new System.Windows.Forms.NumericUpDown();
			this.nudRightCameraXShift = new System.Windows.Forms.NumericUpDown();
			this.nudRightCameraRotation = new System.Windows.Forms.NumericUpDown();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.picLeftCamera)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picRightCamera)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.pnlLeftCamera.SuspendLayout();
			this.pnlRightCamera.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudLeftCameraRotation)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLeftCameraXShift)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLeftCameraYShift)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRightCameraYShift)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRightCameraXShift)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRightCameraRotation)).BeginInit();
			this.SuspendLayout();
			// 
			// picLeftCamera
			// 
			this.picLeftCamera.BackColor = System.Drawing.Color.White;
			this.picLeftCamera.Location = new System.Drawing.Point(3, 3);
			this.picLeftCamera.Margin = new System.Windows.Forms.Padding(0);
			this.picLeftCamera.Name = "picLeftCamera";
			this.picLeftCamera.Size = new System.Drawing.Size(4000, 4000);
			this.picLeftCamera.TabIndex = 0;
			this.picLeftCamera.TabStop = false;
			// 
			// picRightCamera
			// 
			this.picRightCamera.BackColor = System.Drawing.Color.White;
			this.picRightCamera.Location = new System.Drawing.Point(3, 3);
			this.picRightCamera.Margin = new System.Windows.Forms.Padding(0);
			this.picRightCamera.Name = "picRightCamera";
			this.picRightCamera.Size = new System.Drawing.Size(4000, 4000);
			this.picRightCamera.TabIndex = 1;
			this.picRightCamera.TabStop = false;
			// 
			// btnCamerasConnect
			// 
			this.btnCamerasConnect.Location = new System.Drawing.Point(177, 28);
			this.btnCamerasConnect.Name = "btnCamerasConnect";
			this.btnCamerasConnect.Size = new System.Drawing.Size(198, 23);
			this.btnCamerasConnect.TabIndex = 2;
			this.btnCamerasConnect.Text = "Connect (Both)";
			this.btnCamerasConnect.UseVisualStyleBackColor = true;
			this.btnCamerasConnect.Click += new System.EventHandler(this.btnCamerasConnect_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(1, 103);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1554, 539);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.AutoScroll = true;
			this.tabPage1.Controls.Add(this.picLeftCamera);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1546, 513);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Left camera";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.AutoScroll = true;
			this.tabPage2.Controls.Add(this.picRightCamera);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1155, 513);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Right camera";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btnLeftCameraConnectDisconnect
			// 
			this.btnLeftCameraConnectDisconnect.Location = new System.Drawing.Point(177, 86);
			this.btnLeftCameraConnectDisconnect.Name = "btnLeftCameraConnectDisconnect";
			this.btnLeftCameraConnectDisconnect.Size = new System.Drawing.Size(96, 23);
			this.btnLeftCameraConnectDisconnect.TabIndex = 2;
			this.btnLeftCameraConnectDisconnect.Text = "Connect (Left)";
			this.btnLeftCameraConnectDisconnect.UseVisualStyleBackColor = true;
			this.btnLeftCameraConnectDisconnect.Click += new System.EventHandler(this.btnLeftCameraConnectDisconnect_Click);
			// 
			// btnRightCameraConnectDisconnect
			// 
			this.btnRightCameraConnectDisconnect.Location = new System.Drawing.Point(279, 86);
			this.btnRightCameraConnectDisconnect.Name = "btnRightCameraConnectDisconnect";
			this.btnRightCameraConnectDisconnect.Size = new System.Drawing.Size(96, 23);
			this.btnRightCameraConnectDisconnect.TabIndex = 2;
			this.btnRightCameraConnectDisconnect.Text = "Connect (Right)";
			this.btnRightCameraConnectDisconnect.UseVisualStyleBackColor = true;
			this.btnRightCameraConnectDisconnect.Click += new System.EventHandler(this.btnRightCameraConnectDisconnect_Click);
			// 
			// btnRightCameraEnableDisable
			// 
			this.btnRightCameraEnableDisable.Enabled = false;
			this.btnRightCameraEnableDisable.Location = new System.Drawing.Point(501, 86);
			this.btnRightCameraEnableDisable.Name = "btnRightCameraEnableDisable";
			this.btnRightCameraEnableDisable.Size = new System.Drawing.Size(96, 23);
			this.btnRightCameraEnableDisable.TabIndex = 4;
			this.btnRightCameraEnableDisable.Text = "Enable (Right)";
			this.btnRightCameraEnableDisable.UseVisualStyleBackColor = true;
			this.btnRightCameraEnableDisable.Click += new System.EventHandler(this.btnRightCameraEnableDisable_Click);
			// 
			// btnLeftCameraEnableDisable
			// 
			this.btnLeftCameraEnableDisable.Enabled = false;
			this.btnLeftCameraEnableDisable.Location = new System.Drawing.Point(399, 86);
			this.btnLeftCameraEnableDisable.Name = "btnLeftCameraEnableDisable";
			this.btnLeftCameraEnableDisable.Size = new System.Drawing.Size(96, 23);
			this.btnLeftCameraEnableDisable.TabIndex = 5;
			this.btnLeftCameraEnableDisable.Text = "Enable (Left)";
			this.btnLeftCameraEnableDisable.UseVisualStyleBackColor = true;
			this.btnLeftCameraEnableDisable.Click += new System.EventHandler(this.btnLeftCameraEnableDisable_Click);
			// 
			// btnCamerasEnable
			// 
			this.btnCamerasEnable.Location = new System.Drawing.Point(399, 28);
			this.btnCamerasEnable.Name = "btnCamerasEnable";
			this.btnCamerasEnable.Size = new System.Drawing.Size(198, 23);
			this.btnCamerasEnable.TabIndex = 6;
			this.btnCamerasEnable.Text = "Enable (Both)";
			this.btnCamerasEnable.UseVisualStyleBackColor = true;
			this.btnCamerasEnable.Click += new System.EventHandler(this.btnCamerasEnable_Click);
			// 
			// btnRightCameraCapture
			// 
			this.btnRightCameraCapture.Location = new System.Drawing.Point(7, 50);
			this.btnRightCameraCapture.Name = "btnRightCameraCapture";
			this.btnRightCameraCapture.Size = new System.Drawing.Size(138, 23);
			this.btnRightCameraCapture.TabIndex = 10;
			this.btnRightCameraCapture.Text = "Capture";
			this.btnRightCameraCapture.UseVisualStyleBackColor = true;
			this.btnRightCameraCapture.Click += new System.EventHandler(this.btnRightCameraCapture_Click);
			// 
			// btnLeftCameraCapture
			// 
			this.btnLeftCameraCapture.Location = new System.Drawing.Point(7, 50);
			this.btnLeftCameraCapture.Name = "btnLeftCameraCapture";
			this.btnLeftCameraCapture.Size = new System.Drawing.Size(138, 23);
			this.btnLeftCameraCapture.TabIndex = 11;
			this.btnLeftCameraCapture.Text = "Capture";
			this.btnLeftCameraCapture.UseVisualStyleBackColor = true;
			this.btnLeftCameraCapture.Click += new System.EventHandler(this.btnLeftCameraCapture_Click);
			// 
			// btnCamerasCapture
			// 
			this.btnCamerasCapture.Location = new System.Drawing.Point(622, 28);
			this.btnCamerasCapture.Name = "btnCamerasCapture";
			this.btnCamerasCapture.Size = new System.Drawing.Size(105, 81);
			this.btnCamerasCapture.TabIndex = 12;
			this.btnCamerasCapture.Text = "Capture (Both)";
			this.btnCamerasCapture.UseVisualStyleBackColor = true;
			this.btnCamerasCapture.Click += new System.EventHandler(this.btnCamerasCapture_Click);
			// 
			// txtLeftCameraHost
			// 
			this.txtLeftCameraHost.Location = new System.Drawing.Point(53, 30);
			this.txtLeftCameraHost.Name = "txtLeftCameraHost";
			this.txtLeftCameraHost.Size = new System.Drawing.Size(100, 20);
			this.txtLeftCameraHost.TabIndex = 13;
			this.txtLeftCameraHost.Text = "192.168.0.100";
			this.txtLeftCameraHost.Leave += new System.EventHandler(this.txtLeftCameraHost_Leave);
			// 
			// txtRightCameraHost
			// 
			this.txtRightCameraHost.Location = new System.Drawing.Point(53, 59);
			this.txtRightCameraHost.Name = "txtRightCameraHost";
			this.txtRightCameraHost.Size = new System.Drawing.Size(100, 20);
			this.txtRightCameraHost.TabIndex = 13;
			this.txtRightCameraHost.Text = "192.168.0.101";
			this.txtRightCameraHost.Leave += new System.EventHandler(this.txtRightCameraHost_Leave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "Right:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "Left:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(252, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Camera:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(474, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Camera:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(653, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(46, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "Camera:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 9);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(69, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Camera host:";
			// 
			// btnCamerasDisable
			// 
			this.btnCamerasDisable.Location = new System.Drawing.Point(399, 57);
			this.btnCamerasDisable.Name = "btnCamerasDisable";
			this.btnCamerasDisable.Size = new System.Drawing.Size(198, 23);
			this.btnCamerasDisable.TabIndex = 16;
			this.btnCamerasDisable.Text = "Disable (Both)";
			this.btnCamerasDisable.UseVisualStyleBackColor = true;
			this.btnCamerasDisable.Click += new System.EventHandler(this.btnCamerasDisable_Click);
			// 
			// btnCamerasDisconnect
			// 
			this.btnCamerasDisconnect.Location = new System.Drawing.Point(177, 57);
			this.btnCamerasDisconnect.Name = "btnCamerasDisconnect";
			this.btnCamerasDisconnect.Size = new System.Drawing.Size(198, 23);
			this.btnCamerasDisconnect.TabIndex = 15;
			this.btnCamerasDisconnect.Text = "Disconnect (Both)";
			this.btnCamerasDisconnect.UseVisualStyleBackColor = true;
			this.btnCamerasDisconnect.Click += new System.EventHandler(this.btnCamerasDisconnect_Click);
			// 
			// cbxLeftCameraResolution
			// 
			this.cbxLeftCameraResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxLeftCameraResolution.FormattingEnabled = true;
			this.cbxLeftCameraResolution.Location = new System.Drawing.Point(7, 23);
			this.cbxLeftCameraResolution.Name = "cbxLeftCameraResolution";
			this.cbxLeftCameraResolution.Size = new System.Drawing.Size(138, 21);
			this.cbxLeftCameraResolution.TabIndex = 17;
			this.cbxLeftCameraResolution.SelectedIndexChanged += new System.EventHandler(this.cbxLeftCameraResolution_SelectedIndexChanged);
			// 
			// cbxRightCameraResolution
			// 
			this.cbxRightCameraResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxRightCameraResolution.FormattingEnabled = true;
			this.cbxRightCameraResolution.Location = new System.Drawing.Point(7, 23);
			this.cbxRightCameraResolution.Name = "cbxRightCameraResolution";
			this.cbxRightCameraResolution.Size = new System.Drawing.Size(138, 21);
			this.cbxRightCameraResolution.TabIndex = 18;
			this.cbxRightCameraResolution.SelectedIndexChanged += new System.EventHandler(this.cbxRightCameraResolution_SelectedIndexChanged);
			// 
			// btnLeftCameraAutoCapture
			// 
			this.btnLeftCameraAutoCapture.Location = new System.Drawing.Point(7, 79);
			this.btnLeftCameraAutoCapture.Name = "btnLeftCameraAutoCapture";
			this.btnLeftCameraAutoCapture.Size = new System.Drawing.Size(138, 23);
			this.btnLeftCameraAutoCapture.TabIndex = 11;
			this.btnLeftCameraAutoCapture.Text = "Auto capture (Disabled)";
			this.btnLeftCameraAutoCapture.UseVisualStyleBackColor = true;
			this.btnLeftCameraAutoCapture.Click += new System.EventHandler(this.btnLeftCameraAutoCapture_Click);
			// 
			// pnlLeftCamera
			// 
			this.pnlLeftCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlLeftCamera.Controls.Add(this.nudLeftCameraYShift);
			this.pnlLeftCamera.Controls.Add(this.label7);
			this.pnlLeftCamera.Controls.Add(this.nudLeftCameraXShift);
			this.pnlLeftCamera.Controls.Add(this.cbxLeftCameraResolution);
			this.pnlLeftCamera.Controls.Add(this.nudLeftCameraRotation);
			this.pnlLeftCamera.Controls.Add(this.btnLeftCameraCapture);
			this.pnlLeftCamera.Controls.Add(this.label11);
			this.pnlLeftCamera.Controls.Add(this.btnLeftCameraAutoCapture);
			this.pnlLeftCamera.Controls.Add(this.label10);
			this.pnlLeftCamera.Controls.Add(this.label9);
			this.pnlLeftCamera.Enabled = false;
			this.pnlLeftCamera.Location = new System.Drawing.Point(736, 5);
			this.pnlLeftCamera.Name = "pnlLeftCamera";
			this.pnlLeftCamera.Size = new System.Drawing.Size(293, 112);
			this.pnlLeftCamera.TabIndex = 19;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(4, 4);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(28, 13);
			this.label7.TabIndex = 15;
			this.label7.Text = "Left:";
			// 
			// pnlRightCamera
			// 
			this.pnlRightCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlRightCamera.Controls.Add(this.nudRightCameraYShift);
			this.pnlRightCamera.Controls.Add(this.nudRightCameraXShift);
			this.pnlRightCamera.Controls.Add(this.nudRightCameraRotation);
			this.pnlRightCamera.Controls.Add(this.label12);
			this.pnlRightCamera.Controls.Add(this.label13);
			this.pnlRightCamera.Controls.Add(this.label14);
			this.pnlRightCamera.Controls.Add(this.label8);
			this.pnlRightCamera.Controls.Add(this.btnRightCameraAutoCapture);
			this.pnlRightCamera.Controls.Add(this.cbxRightCameraResolution);
			this.pnlRightCamera.Controls.Add(this.btnRightCameraCapture);
			this.pnlRightCamera.Enabled = false;
			this.pnlRightCamera.Location = new System.Drawing.Point(1035, 5);
			this.pnlRightCamera.Name = "pnlRightCamera";
			this.pnlRightCamera.Size = new System.Drawing.Size(293, 112);
			this.pnlRightCamera.TabIndex = 20;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(4, 4);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 13);
			this.label8.TabIndex = 15;
			this.label8.Text = "Right:";
			// 
			// btnRightCameraAutoCapture
			// 
			this.btnRightCameraAutoCapture.Location = new System.Drawing.Point(7, 79);
			this.btnRightCameraAutoCapture.Name = "btnRightCameraAutoCapture";
			this.btnRightCameraAutoCapture.Size = new System.Drawing.Size(138, 23);
			this.btnRightCameraAutoCapture.TabIndex = 11;
			this.btnRightCameraAutoCapture.Text = "Auto capture (Disabled)";
			this.btnRightCameraAutoCapture.UseVisualStyleBackColor = true;
			this.btnRightCameraAutoCapture.Click += new System.EventHandler(this.btnRightCameraAutoCapture_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(163, 26);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(50, 13);
			this.label9.TabIndex = 22;
			this.label9.Text = "Rotation:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(163, 54);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(41, 13);
			this.label10.TabIndex = 22;
			this.label10.Text = "X Shift:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(163, 84);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(41, 13);
			this.label11.TabIndex = 22;
			this.label11.Text = "Y Shift:";
			// 
			// nudLeftCameraRotation
			// 
			this.nudLeftCameraRotation.DecimalPlaces = 1;
			this.nudLeftCameraRotation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.nudLeftCameraRotation.Location = new System.Drawing.Point(219, 24);
			this.nudLeftCameraRotation.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.nudLeftCameraRotation.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.nudLeftCameraRotation.Name = "nudLeftCameraRotation";
			this.nudLeftCameraRotation.Size = new System.Drawing.Size(62, 20);
			this.nudLeftCameraRotation.TabIndex = 23;
			this.nudLeftCameraRotation.Leave += new System.EventHandler(this.nudLeftCameraRotation_Leave);
			// 
			// nudLeftCameraXShift
			// 
			this.nudLeftCameraXShift.DecimalPlaces = 1;
			this.nudLeftCameraXShift.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.nudLeftCameraXShift.Location = new System.Drawing.Point(219, 53);
			this.nudLeftCameraXShift.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudLeftCameraXShift.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.nudLeftCameraXShift.Name = "nudLeftCameraXShift";
			this.nudLeftCameraXShift.Size = new System.Drawing.Size(62, 20);
			this.nudLeftCameraXShift.TabIndex = 23;
			this.nudLeftCameraXShift.Leave += new System.EventHandler(this.nudLeftCameraXShift_Leave);
			// 
			// nudLeftCameraYShift
			// 
			this.nudLeftCameraYShift.DecimalPlaces = 1;
			this.nudLeftCameraYShift.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.nudLeftCameraYShift.Location = new System.Drawing.Point(219, 82);
			this.nudLeftCameraYShift.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudLeftCameraYShift.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.nudLeftCameraYShift.Name = "nudLeftCameraYShift";
			this.nudLeftCameraYShift.Size = new System.Drawing.Size(62, 20);
			this.nudLeftCameraYShift.TabIndex = 23;
			this.nudLeftCameraYShift.Leave += new System.EventHandler(this.nudLeftCameraYShift_Leave);
			// 
			// nudRightCameraYShift
			// 
			this.nudRightCameraYShift.DecimalPlaces = 1;
			this.nudRightCameraYShift.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.nudRightCameraYShift.Location = new System.Drawing.Point(220, 82);
			this.nudRightCameraYShift.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudRightCameraYShift.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.nudRightCameraYShift.Name = "nudRightCameraYShift";
			this.nudRightCameraYShift.Size = new System.Drawing.Size(62, 20);
			this.nudRightCameraYShift.TabIndex = 27;
			this.nudRightCameraYShift.Leave += new System.EventHandler(this.nudRightCameraYShift_Leave);
			// 
			// nudRightCameraXShift
			// 
			this.nudRightCameraXShift.DecimalPlaces = 1;
			this.nudRightCameraXShift.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.nudRightCameraXShift.Location = new System.Drawing.Point(220, 53);
			this.nudRightCameraXShift.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudRightCameraXShift.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.nudRightCameraXShift.Name = "nudRightCameraXShift";
			this.nudRightCameraXShift.Size = new System.Drawing.Size(62, 20);
			this.nudRightCameraXShift.TabIndex = 28;
			this.nudRightCameraXShift.Leave += new System.EventHandler(this.nudRightCameraXShift_Leave);
			// 
			// nudRightCameraRotation
			// 
			this.nudRightCameraRotation.DecimalPlaces = 1;
			this.nudRightCameraRotation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.nudRightCameraRotation.Location = new System.Drawing.Point(220, 24);
			this.nudRightCameraRotation.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.nudRightCameraRotation.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
			this.nudRightCameraRotation.Name = "nudRightCameraRotation";
			this.nudRightCameraRotation.Size = new System.Drawing.Size(62, 20);
			this.nudRightCameraRotation.TabIndex = 29;
			this.nudRightCameraRotation.Leave += new System.EventHandler(this.nudRightCameraRotation_Leave);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(164, 84);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(41, 13);
			this.label12.TabIndex = 24;
			this.label12.Text = "Y Shift:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(164, 54);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(41, 13);
			this.label13.TabIndex = 25;
			this.label13.Text = "X Shift:";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(164, 26);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(50, 13);
			this.label14.TabIndex = 26;
			this.label14.Text = "Rotation:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1559, 645);
			this.Controls.Add(this.pnlRightCamera);
			this.Controls.Add(this.pnlLeftCamera);
			this.Controls.Add(this.btnCamerasDisable);
			this.Controls.Add(this.btnCamerasDisconnect);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtRightCameraHost);
			this.Controls.Add(this.txtLeftCameraHost);
			this.Controls.Add(this.btnCamerasCapture);
			this.Controls.Add(this.btnRightCameraEnableDisable);
			this.Controls.Add(this.btnLeftCameraEnableDisable);
			this.Controls.Add(this.btnCamerasEnable);
			this.Controls.Add(this.btnRightCameraConnectDisconnect);
			this.Controls.Add(this.btnLeftCameraConnectDisconnect);
			this.Controls.Add(this.btnCamerasConnect);
			this.Controls.Add(this.tabControl1);
			this.Name = "MainForm";
			this.Text = "RPi Capture";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.picLeftCamera)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picRightCamera)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.pnlLeftCamera.ResumeLayout(false);
			this.pnlLeftCamera.PerformLayout();
			this.pnlRightCamera.ResumeLayout(false);
			this.pnlRightCamera.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudLeftCameraRotation)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLeftCameraXShift)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudLeftCameraYShift)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRightCameraYShift)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRightCameraXShift)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudRightCameraRotation)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox picLeftCamera;
		private System.Windows.Forms.PictureBox picRightCamera;
		private System.Windows.Forms.Button btnCamerasConnect;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button btnLeftCameraConnectDisconnect;
		private System.Windows.Forms.Button btnRightCameraConnectDisconnect;
		private System.Windows.Forms.Button btnRightCameraEnableDisable;
		private System.Windows.Forms.Button btnLeftCameraEnableDisable;
		private System.Windows.Forms.Button btnCamerasEnable;
		private System.Windows.Forms.Button btnRightCameraCapture;
		private System.Windows.Forms.Button btnLeftCameraCapture;
		private System.Windows.Forms.Button btnCamerasCapture;
		private System.Windows.Forms.TextBox txtLeftCameraHost;
		private System.Windows.Forms.TextBox txtRightCameraHost;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnCamerasDisable;
		private System.Windows.Forms.Button btnCamerasDisconnect;
		private System.Windows.Forms.ComboBox cbxLeftCameraResolution;
		private System.Windows.Forms.ComboBox cbxRightCameraResolution;
		private System.Windows.Forms.Button btnLeftCameraAutoCapture;
		private System.Windows.Forms.Panel pnlLeftCamera;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Panel pnlRightCamera;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnRightCameraAutoCapture;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.NumericUpDown nudLeftCameraRotation;
		private System.Windows.Forms.NumericUpDown nudLeftCameraXShift;
		private System.Windows.Forms.NumericUpDown nudLeftCameraYShift;
		private System.Windows.Forms.NumericUpDown nudRightCameraYShift;
		private System.Windows.Forms.NumericUpDown nudRightCameraXShift;
		private System.Windows.Forms.NumericUpDown nudRightCameraRotation;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
	}
}

