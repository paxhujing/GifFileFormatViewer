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

        /// <summary>
        /// 87a版本。
        /// </summary>
        public const String GIF87AVersion = "87a";

        /// <summary>
        /// 89a版本。
        /// </summary>
        public const String GIF89AVersion = "89a";

        #endregion

        #region Constructors

        /// <summary>
        /// 初始化类型 GifFileFormatViewer.GifParser  实例。
        /// </summary>
        public GifParser()
        {
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

        /// <summary>
        /// 全局调色板。
        /// </summary>
        public ColorTable? GlobalColorTable { get; private set; }

        #endregion

        #region Methods

        #region Public

        /// <summary>
        /// 初始化。
        /// </summary>
        /// <param name="stream">表示GIF图像的流。</param>
        public void Initialize(Stream stream)
        {
            stream.Position = 0;
            Byte[] data = new Byte[stream.Length];
            stream.Read(data, 0, data.Length);
            Int32 offset = 0;
            offset += ParseHeader(data, offset);
            offset += ParseLogicalScreenDescriptorAndGlobalColorTable(data, offset);
            ParseBlock(data, offset);
        }

        #endregion

        #region Private

        /// <summary>
        /// 解析文件头。
        /// </summary>
        /// <param name="data">原始数据。</param>
        /// <param name="offset">偏移量。</param>
        /// <returns>块长度。</returns>
        private Int32 ParseHeader(Byte[] data, Int32 offset)
        {
            Header header = new Header(data, offset);
            if (header.Signature != Signature)
            {
                throw new FormatException("Invalid GIF file");
            }
            Header = header;
            return header.Length;
        }

        /// <summary>
        /// 解析逻辑屏幕描述符和全局调色板。
        /// </summary>
        /// <param name="data">原始数据。</param>
        /// <param name="offset">偏移量。</param>
        /// <returns>块长度。</returns>
        private Int32 ParseLogicalScreenDescriptorAndGlobalColorTable(Byte[] data, Int32 offset)
        {
            LogicalScreenDescriptor logicalScreenDescriptor = new LogicalScreenDescriptor(data, offset);
            LogicalScreenDescriptor = logicalScreenDescriptor;
            offset += logicalScreenDescriptor.Length;
            Int32 globalColorTableSize = 0;
            if (logicalScreenDescriptor.Pack.GlobalColorTableFlag)
            {
                globalColorTableSize = (Int32)Math.Pow(2, logicalScreenDescriptor.Pack.SizeOfTheGlobalColor + 1) * 3;
                GlobalColorTable = new ColorTable(data, offset, globalColorTableSize);
                offset += globalColorTableSize;
            }
            return logicalScreenDescriptor.Length + globalColorTableSize;
        }

        /// <summary>
        /// 解析块数据。
        /// </summary>
        /// <param name="data">原始数据。</param>
        /// <param name="offset">偏移量。</param>
        private void ParseBlock(Byte[] data, Int32 offset)
        {
            switch ((BlockIntroducer)data[offset])
            {
                case BlockIntroducer.ExtensionBlock:
                    switch ((ExtensionBlockIdentifier)data[offset + 1])
                    {
                        case ExtensionBlockIdentifier.GraphicControl:
                            new GraphicControlExtensionBlock(data, offset);
                            break;
                        case ExtensionBlockIdentifier.PlainText:
                            new PlainTextExtensionBlock(data, offset);
                            break;
                        case ExtensionBlockIdentifier.Application:
                            new ApplicationExtensionBlock(data, offset);
                            break;
                        default:
                            throw new FormatException($"Unknow extension block identifier.{data[offset]}");
                    }
                    break;
                case BlockIntroducer.ImageDescriptor:
                    break;
                case BlockIntroducer.Trailer:
                    break;
                default:
                    throw new FormatException($"Unknow block introducer.{data[offset]}");
            }
        }

        #endregion

        #endregion

    }
}
