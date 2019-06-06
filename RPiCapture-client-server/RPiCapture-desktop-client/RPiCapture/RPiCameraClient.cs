using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RPiCapture
{
	enum FrameType
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
		COT_Resize = 1,
		COT_Enable,
		COT_Disable,
		COT_GetImage
	}

	public class Image
	{
		public UInt16 Width { get; private set; }
		public UInt16 Height { get; private set; }

		public byte[] Data { get; private set; }

		public Image(UInt16 width, UInt16 height, byte[] data)
		{
			this.Width = width;
			this.Height = height;

			this.Data = data;
		}
	}

	public class RPiCameraClient
	{
		#region Variables

		private TcpClient _clinet = null;
		private NetworkStream _stream = null;

		private BinaryReader _reader = null;
		private BinaryWriter _writer = null;

		#endregion

		#region Properties

		/// <summary>
		/// Gets information about connection state.
		/// </summary>
		public bool Connected
		{
			get { return this._clinet != null; }
		}

		/// <summary>
		/// Gets enabled camera status.
		/// </summary>
		public bool Enabled { get; private set; }
		
		/// <summary>
		/// Gets camera width.
		/// </summary>
		public UInt16 Width { get; private set; }

		/// <summary>
		/// Gets camera height.
		/// </summary>
		public UInt16 Height { get; private set; }

		#endregion

		#region Public methods

		public bool Connect(string hostname, int port)
		{
			if (this._clinet != null)
				return false;

			try
			{
				this._clinet = new TcpClient(hostname, port);
				this._stream = this._clinet.GetStream();

				this._reader = new BinaryReader(this._stream);
				this._writer = new BinaryWriter(this._stream);

				this.Enabled = this._reader.ReadBoolean();

				this.Width = this._reader.ReadUInt16();
				this.Height = this._reader.ReadUInt16();

				return true;
			}
			catch (Exception)
			{
				this.Disconnect();

				return false;
			}
		}

		public bool Disconnect()
		{
			if (this._clinet == null)
				return false;

			if (this._writer != null)
			{
				this._writer.Close();
				this._writer = null;
			}

			if (this._reader != null)
			{
				this._reader.Close();
				this._reader = null;
			}

			if (this._stream != null)
			{
				this._stream.Close();
				this._stream = null;
			}

			this._clinet.Close();
			this._clinet = null;

			return true;
		}

		public bool Resize(UInt16 width, UInt16 height)
		{
			if (this._clinet == null)
				return false;

			try
			{
				this._writer.Write((byte)FrameType.FT_Camera);
				this._writer.Write((byte)CameraOperationType.COT_Resize);
				this._writer.Write(width);
				this._writer.Write(height);

				return this._reader.ReadBoolean();
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool Enable()
		{
			if (this._clinet == null)
				return false;

			try
			{
				this._writer.Write((byte)FrameType.FT_Camera);
				this._writer.Write((byte)CameraOperationType.COT_Enable);

				return (this.Enabled = this._reader.ReadBoolean());
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool Disable()
		{
			if (this._clinet == null)
				return false;

			try
			{
				this._writer.Write((byte)FrameType.FT_Camera);
				this._writer.Write((byte)CameraOperationType.COT_Disable);

				if (this._reader.ReadBoolean())
				{
					this.Enabled = false;

					return true;
				}

				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public Image Capture()
		{
			if (this._clinet == null)
				return null;

			try
			{
				this._writer.Write((byte)FrameType.FT_Camera);
				this._writer.Write((byte)CameraOperationType.COT_GetImage);

				if (this._reader.ReadBoolean())
				{
					UInt16 width = this._reader.ReadUInt16();
					UInt16 height = this._reader.ReadUInt16();

					byte[] data = new byte[width * height * 3];

					for (int i = 0; i < data.Length; )
					{
						int tmp = this._reader.Read(data, i, data.Length - i);

						if (tmp == -1)
							return null;

						i += tmp;
					}

					return new Image(width, height, data);
				}

				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}

		#endregion
	}
}
