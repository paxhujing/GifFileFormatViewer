using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifFileFormatViewer
{
    /// <summary>
    /// 应用程序扩展块。
    /// </summary>
    public class ApplicationExtensionBlock : ExtensionBlock
    {
        #region Constructors

        /// <summary>
        /// 初始化类型 GifFileFormatViewer.ApplicationExtensionBlock 实例。
        /// </summary>
        /// <param name="data">原始数据。</param>
        /// <param name="offset">偏移量。</param>
        public ApplicationExtensionBlock(Byte[] data, Int32 offset)
            : base(data, offset, ExtensionBlockIdentifier.Application)
        {
            ApplicationIdentifier = ASCIIEncoding.ASCII.GetString(data, offset + 3, 8);
            Byte[] ac = new Byte[3];
            Array.Copy(data, offset + 11, ac, 0, 3);
            AuthenticationCode = ac;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 块长度（字节）。
        /// </summary>
        public override Int32 Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 包含8个ASCII字符，用于标识应用程序。
        /// 如果该字符串能够被识别，那么接下来部分的数据可被读取并处理。
        /// </summary>
        public String ApplicationIdentifier { get; }

        /// <summary>
        /// 由特定应用程序生成，用于唯一标识该应用程序或计算机平台。
        /// 该数据可以是一个序列号、版本号或者唯一二进制编码或者ASCII编码。
        /// </summary>
        public Byte[] AuthenticationCode { get; }

        #endregion
    }
}
