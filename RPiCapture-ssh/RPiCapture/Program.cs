using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPiCapture
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}

	public enum FrameType
	{
		FT_Undefined = 0,
		FT_Camera = 1,
	//    FT_Led,
	//    FT_Gyro,
	//    FT_Temperature,
		FT_Shutdown // zatrzymuje serwer
	}

	enum CameraOperationType
	{
		COT_Undefined = 0,
		COT_Enable = 1,
		COT_Disable,
		COT_GetImage
	}
}
