using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GifFileFormatViewer
{
    /// <summary>
    /// GIF文件解析器。
    /// </summary>
    public class GifParser
    {
        #region Fields

        /// <summary>
        /// GIF文件签名。
        /// </summary>
        private const String Signature = "GIF";

        #endregion

        #region Fields

        private readonly Byte[] _data;

        #endregion

        #region Constructors

        /// <summary>
        /// 初始化类型 GifFileFormatViewer.GifParser  实例。
        /// </summary>
        /// <param name="stream">表示GIF图像的流。</param>
        public GifParser(Stream stream)
        {
            stream.Position = 0;
            Byte[] data = new Byte[stream.Length];
            stream.Read(data, 0, data.Length);
            _data = data;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 文件头。
        /// </summary>
        public Header Header { get; private set; }

        /// <summary>
        /// 逻辑屏幕描述符。
        /// </summary>
        public LogicalScreenDescriptor LogicalScreenDescriptor { get; private set; }

        #endregion

        #region Methods

        #region Public

        public void Initialize()
        {
            Int32 offset = 0;
            Header header = new Header(_data, offset);
            //if (header.Signature != Signature)
            //{
            //    throw new FormatException("Invalid GIF file");
            //}
            Header = header;
            offset += Marshal.SizeOf(header);
            LogicalScreenDescriptor logicalScreenDescriptor = new LogicalScreenDescriptor(_data, offset);
            offset += Marshal.SizeOf(logicalScreenDescriptor);
        }

        #endregion

        #endregion

    }
}
