using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifFileFormatViewer
{
    /// <summary>
    /// 图像控制扩展块。
    /// </summary>
    public class GraphicControlExtensionBlock: ExtensionBlock
    {
        #region Constructors

        /// <summary>
        /// 初始化类型 GifFileFormatViewer.GraphicControlExtensionBlock 实例。
        /// </summary>
        /// <param name="data">原始数据。</param>
        /// <param name="offset">偏移量。</param>
        public GraphicControlExtensionBlock(Byte[] data, Int32 offset)
            : base(data, offset, ExtensionBlockIdentifier.GraphicControl)
        {

        }

        #endregion

        #region Nested Type

        /// <summary>
        /// 包装域掩码。
        /// </summary>
        [Flags]
        internal enum PackedMask : Byte
        {
            /// <summary>
            /// 用于表示是否启用透明色。如果为1，则指示处理程序修改显示设备上的相应像素点。
            /// </summary>
            TransparentFlagMask = 0x01,
            /// <summary>
            /// 表示在继续处理之前是否需要用户输入响应。如果DelayTime被设置，那么继续处理的开始时间
            /// 取决于用户响应输入是在延迟时间之前还是之后。
            /// </summary>
            UserInputFlagMask = 0x02,
            DisposalMethodMask = 0x1C,
            ReservedMask = 0xE0,
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
