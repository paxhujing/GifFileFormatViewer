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
    [StructLayout(LayoutKind.Explicit)]
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
            _signature = new Byte[3];
            Array.Copy(data, offset, _signature, 0, 3);
            _version = new Byte[3];
            Array.Copy(data, offset + 3, _version, 0, 3);
        }

        #endregion

        #region Properties

        #region Signature

        [FieldOffset(0)]
        private Byte[] _signature;

        /// <summary>
        /// 签名。
        /// </summary>
        public String Signature => ASCIIEncoding.ASCII.GetString(_signature);

        #endregion

        #region Version

        [FieldOffset(3)]
        private Byte[] _version;
        /// <summary>
        /// 版本。
        /// </summary>
        public String Version => ASCIIEncoding.ASCII.GetString(_version);

        #endregion

        #endregion
    }
}
