using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifFileFormatViewer
{
    /// <summary>
    /// 块类型指示符。
    /// </summary>
    public enum BlockIntroducer : Byte
    {
        /// <summary>
        /// 标识这是一个ImageDescriptor块。
        /// </summary>
        ImageDescriptor = 0x2c,
        /// <summary>
        /// 标识这是一个扩展块。
        /// </summary>
        ExtensionBlock = 0x21,
        /// <summary>
        /// 标识这是文件结束块。
        /// </summary>
        Trailer = 0x3B,
    }
}
