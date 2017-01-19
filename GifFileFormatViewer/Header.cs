using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GifFileFormatViewer
{
    /// <summary>
    /// GIF文件头。
    /// </summary>
    public struct Header
    {
        #region Constructors

        /// <summary>
        /// 初始化结构 GifFileFormatViewer.Header 实例。
        /// </summary>
        /// <param name="data">原始数据。</param>
        /// <param name="offset">偏移量。</param>
        public Header(Byte[] data, Int32 offset)
        {
            Signature = ASCIIEncoding.ASCII.GetString(data, offset, 3);
            Version = ASCIIEncoding.ASCII.GetString(data, offset + 3, 3);
            Length = 6;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 字节长度。
        /// </summary>
        internal Int32 Length { get; }

        #region Signature

        /// <summary>
        /// 签名。
        /// </summary>
        public String Signature { get; }

        #endregion

        #region Version
        /// <summary>
        /// 版本。
        /// </summary>
        public String Version { get; }

        #endregion

        #endregion
    }
}
