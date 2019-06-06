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
			this.btnCameraCapture = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.picLeftCamera)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picRightCamera)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// picLeftCamera
			// 
			this.picLeftCamera.BackColor = System.Drawing.Color.White;
			this.picLeftCamera.Location = new System.Drawing.Point(6, 3);
			this.picLeftCamera.Name = "picLeftCamera";
			this.picLeftCamera.Size = new System.Drawing.Size(4000, 4000);
			this.picLeftCamera.TabIndex = 0;
			this.picLeftCamera.TabStop = false;
			// 
			// picRightCamera
			// 
			this.picRightCamera.BackColor = System.Drawing.Color.White;
			this.picRightCamera.Location = new System.Drawing.Point(3, 6);
			this.picRightCamera.Name = "picRightCamera";
			this.picRightCamera.Size = new System.Drawing.Size(4000, 4000);
			this.picRightCamera.TabIndex = 1;
			this.picRightCamera.TabStop = false;
			// 
			// btnCameraCapture
			// 
			this.btnCameraCapture.Location = new System.Drawing.Point(169, 5);
			this.btnCameraCapture.Name = "btnCameraCapture";
			this.btnCameraCapture.Size = new System.Drawing.Size(96, 23);
			this.btnCameraCapture.TabIndex = 2;
			this.btnCameraCapture.Text = "Capture";
			this.btnCameraCapture.UseVisualStyleBackColor = true;
			this.btnCameraCapture.Click += new System.EventHandler(this.btnCameraCapture_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(1, 11);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1163, 631);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.AutoScroll = true;
			this.tabPage1.Controls.Add(this.picLeftCamera);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1155, 605);
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
			this.tabPage2.Size = new System.Drawing.Size(1155, 605);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Right camera";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1168, 645);
			this.Controls.Add(this.btnCameraCapture);
			this.Controls.Add(this.tabControl1);
			this.Name = "MainForm";
			this.Text = "RPi Capture";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.picLeftCamera)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picRightCamera)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox picLeftCamera;
		private System.Windows.Forms.PictureBox picRightCamera;
		private System.Windows.Forms.Button btnCameraCapture;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
	}
}

