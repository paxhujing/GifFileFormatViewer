using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifFileFormatViewer
{
    /// <summary>
    /// 扩展块。
    /// </summary>
    public abstract class ExtensionBlock
    {
        #region Constructors

        /// <summary>
        /// 初始化类型 GifFileFormatViewer.ExtensionBlock 实例。
        /// </summary>
        /// <param name="data">原始数据。</param>
        /// <param name="offset">偏移量。</param>
        /// <param name="identifier">块标识。</param>
        protected ExtensionBlock(Byte[] data, Int32 offset, ExtensionBlockIdentifier identifier)
        {
            BlockSize = data[offset + 2];
            Identifier = identifier;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 块类型指示符。
        /// </summary>
        public BlockIntroducer Introducer { get; } = BlockIntroducer.ExtensionBlock;

        /// <summary>
        /// 块标识。
        /// </summary>
        public ExtensionBlockIdentifier Identifier { get; }

        /// <summary>
        /// 块长度（字节）。
        /// </summary>
        public abstract Int32 Length { get; }

        /// <summary>
        /// 从BlockSize域之后到Terminator域之间的字节数。
        /// </summary>
        public Byte BlockSize { get; }

        #endregion
    }
}
