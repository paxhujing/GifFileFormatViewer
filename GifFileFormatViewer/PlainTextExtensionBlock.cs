using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifFileFormatViewer
{
    /// <summary>
    /// 无格式文本扩展块。
    /// </summary>
    public class PlainTextExtensionBlock : ExtensionBlock
    {
        #region Constructors

        /// <summary>
        /// 初始化类型 GifFileFormatViewer.PlainTextExtensionBlock 实例。
        /// </summary>
        /// <param name="data">原始数据。</param>
        /// <param name="offset">偏移量。</param>
        public PlainTextExtensionBlock(Byte[] data, Int32 offset)
            : base(data, offset, ExtensionBlockIdentifier.PlainText)
        {

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

        #endregion
    }
}
