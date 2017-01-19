using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifFileFormatViewer
{
    /// <summary>
    /// 扩展块标识。
    /// </summary>
    public enum ExtensionBlockIdentifier : Byte
    {
        /// <summary>
        /// 图像控制扩展块。
        /// </summary>
        GraphicControl = 0xF9,
        /// <summary>
        /// 无格式文本扩展块。
        /// </summary>
        PlainText = 0x01,
        /// <summary>
        /// 应用程序扩展块。
        /// </summary>
        Application = 0xFF,
    }
}
