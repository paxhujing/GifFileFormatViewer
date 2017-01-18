using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifFileFormatViewer
{
    /// <summary>
    /// 逻辑屏幕描述符。
    /// </summary>
    public struct LogicalScreenDescriptor
    {
        #region Fields

        private readonly Byte[] _data;

        #endregion

        #region Constructors

        /// <summary>
        /// 初始化结构 GifFileFormatViewer.LogicalScreenDescriptor 实例。
        /// </summary>
        /// <param name="data">原始数据。</param>
        /// <param name="offset">偏移量。</param>
        public LogicalScreenDescriptor(Byte[] data, Int32 offset)
        {
            _data = data;
            LogicalScreenWidth = BitConverter.ToUInt16(_data, offset);
            LogicalScreenHeight = BitConverter.ToUInt16(_data, offset + 2);
            Pack = new PackField(_data[offset + 4]);
            BackgroundColorIndex = _data[offset + 5];
            AspectRatio = _data[offset + 6];
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
            /// 表示用于检索调色板的索引号的位数（实际值减1），用来计算全局调色板大小。
            /// 如果GlobalColorTableFlag所在的位值为0，则不需要计算全局调色板大小。
            /// </summary>
            SizeOfGlobalColorTableMask = 0x07,
            /// <summary>
            /// 表示全局调色板中的颜色是否按重要性（或使用率）排序。
            /// 这样做的目的是辅助颜色较少的解码器能够选择最好的颜色子集。
            /// 在这种情况下解码器就可以选择调色板中开始段的颜色来显示图像。
            /// </summary>
            GlobalColorTableSortFlagMask = 0x08,
            /// <summary>
            /// 表示原始图像可用的基色的位数。也就是原始调色板中每种颜色的位数（实际值减1）,可用来计算原色调色板的大小。
            /// </summary>
            ColorResolutionMask = 0x70,
            /// <summary>
            /// 全局调色板存在标记。如果为1表示在 LogicalScreenDescriptor 后紧跟着一个全局调色板。
            /// </summary>
            GlobalColorTableFlagMask = 0x80
        }

        /// <summary>
        /// 包装域。
        /// </summary>
        public struct PackField
        {
            #region Fields

            private readonly Byte _packField;

            #endregion

            #region Constructors

            /// <summary>
            /// 初始化结构 GifFileFormatViewer.LogicalScreenDescriptor.PackField 实例。
            /// </summary>
            /// <param name="packField">包装域的值。</param>
            public PackField(Byte packField)
            {
                _packField = packField;
            }

            #endregion

            #region Properties

            /// <summary>
            /// 表示用于检索调色板的索引号的位数（实际值减1），用来计算全局调色板大小。
            /// 如果GlobalColorTableFlag所在的位值为0，则不需要计算全局调色板大小。
            /// </summary>
            public Byte SizeOfTheGlobalColor => (Byte)(_packField & (Byte)PackedMask.SizeOfGlobalColorTableMask);

            /// <summary>
            /// 表示全局调色板中的颜色是否按重要性（或使用率）排序。
            /// 这样做的目的是辅助颜色较少的解码器能够选择最好的颜色子集。
            /// 在这种情况下解码器就可以选择调色板中开始段的颜色来显示图像。
            /// </summary>
            public Boolean GlobalColorTableSortFlag => (_packField & (Byte)PackedMask.GlobalColorTableSortFlagMask) != 0;

            /// <summary>
            /// 表示原始图像可用的基色的位数。也就是原始调色板中每种颜色的位数（实际值减1）,可用来计算原色调色板的大小。
            /// </summary>
            public Byte ColorResolution => (Byte)(_packField & (Byte)PackedMask.ColorResolutionMask);

            /// <summary>
            /// 全局调色板存在标记。如果为1表示在 LogicalScreenDescriptor 后紧跟着一个全局调色板。
            /// </summary>
            public Boolean GlobalColorTableFlag => (_packField & (Byte)PackedMask.GlobalColorTableFlagMask) != 0;

            #endregion
        }

        #endregion

        #region Properties

        /// <summary>
        /// 逻辑屏幕宽度（像素）。
        /// </summary>
        public UInt16 LogicalScreenWidth { get; }

        /// <summary>
        /// 逻辑屏幕高度（像素）。
        /// </summary>
        public UInt16 LogicalScreenHeight { get; }

        /// <summary>
        /// 包装域。
        /// </summary>
        public PackField Pack { get; }

        /// <summary>
        /// 背景色索引号。
        /// </summary>
        public Byte BackgroundColorIndex { get; }

        /// <summary>
        /// 如果为0，表示未指定宽高比。
        /// 宽度的像素除以高度的像素，其值在1到255之间。
        /// </summary>
        public Byte AspectRatio { get; }

        #endregion
    }
}
