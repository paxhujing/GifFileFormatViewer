using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifFileFormatViewer
{
    public class GifParser
    {
        #region Fields

        private readonly Stream _stream;

        #endregion

        public GifParser(Stream stream)
        {
            stream.Read(null, 0, 3);
        }

    }
}
