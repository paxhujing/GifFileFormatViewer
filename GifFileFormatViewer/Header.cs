using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="signature">签名。</param>
        /// <param name="version">版本。</param>
        public Header(String signature,String version)
        {
            Signature = signature;
            Version = version;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 签名。
        /// </summary>
        public String Signature { get;}

        /// <summary>
        /// 版本。
        /// </summary>
        public String Version { get; }

        #endregion
    }
}
