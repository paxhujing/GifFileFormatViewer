using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifFileFormatViewer
{
    /// <summary>
    /// 调色板。
    /// </summary>
    public struct ColorTable
    {
        #region Constructors

        /// <summary>
        /// 初始化结构 GifFileFormatViewer.ColorTable 实例。
        /// </summary>
        /// <param name="data">原始数据。</param>
        /// <param name="offset">偏移量。</param>
        /// <param name="length">以字节为单位的长度。</param>
        public ColorTable(Byte[] data,Int32 offset,Int32 length)
        {
            RGB[] colors = new RGB[length / 3];
            Int32 index = 0;
            for (Int32 i = 0; i < length; i += 3)
            {
                colors[index++] = new RGB(data[offset + i], data[offset + i + 1], data[offset + i + 2]);
            }
            Colors = colors;
            Length = length;
        }

        #endregion

        #region Nested Type

        /// <summary>
        /// 颜色表中的RGB值。
        /// </summary>
        public struct RGB
        {
            #region Fields

            private readonly String _str;

            #endregion

            #region Constructors

            /// <summary>
            /// 初始化结构 GifFileFormatViewer.ColorTable.RGB 实例。
            /// </summary>
            /// <param name="red">红色分量。</param>
            /// <param name="green">绿色分量。</param>
            /// <param name="blue">蓝色分量。</param>
            public RGB(Byte red, Byte green, Byte blue)
            {
                Red = red;
                Green = green;
                Blue = blue;

                Int32 value = 0;
                value |= red << 16;
                value |= green << 8;
                value |= blue;
                _str = $"0x{String.Format("{0:X6}", value)}";
            }

            #endregion

            #region Properties

            /// <summary>
            /// 红色分量。
            /// </summary>
            public Byte Red { get; }

            /// <summary>
            /// 绿色分量。
            /// </summary>
            public Byte Green { get; }

            /// <summary>
            /// 蓝色分量。
            /// </summary>
            public Byte Blue { get; }

            #endregion

            #region Methods

            /// <summary>
            /// 获取实例的字符串表示。
            /// </summary>
            /// <returns>字符串表示。</returns>
            public override String ToString()
            {
                return _str;
            }

            #endregion
        }

        #endregion

        #region Properties

        /// <summary>
        /// 颜色表的字节长度。
        /// </summary>
        internal Int32 Length { get; }

        /// <summary>
        /// 颜色值列表。
        /// </summary>
        public RGB[] Colors { get; }

        #endregion
    }
}
