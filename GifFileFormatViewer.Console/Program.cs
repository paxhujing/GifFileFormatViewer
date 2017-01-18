using GifFileFormatViewer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifFileFormatViewer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Stream stream = File.Open(@"d:\splash_loading.gif", FileMode.Open))
            {
                GifParser parser = new GifParser(stream);
                parser.Initialize();
            }
        }
    }
}
