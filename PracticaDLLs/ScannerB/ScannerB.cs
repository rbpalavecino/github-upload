using RoboCorp.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCorp
{
    public class ScannerB
    {
        const string DPI_100_FOLDER = @"..\..\..\Img_Cheques\100_DPI";
        const string DPI_200_FOLDER = @"..\..\..\Img_Cheques\200_DPI";
        const string DPI_300_FOLDER = @"..\..\..\Img_Cheques\300_DPI";
        const int CMC7_LENGTH = 29;

        public enum Resolution { DPI_100, DPI_200, DPI_300}

        public Resolution ImageRes { get; set; } = Resolution.DPI_300;
        
        private bool _initialized = false;

        public byte[] Scan(out string CMC7)
        {
            if (!_initialized) throw new ScannerNotInitException();

            using (MemoryStream stream = new MemoryStream())
            {
                string imagePath = GetRandomImage(this.ImageRes);

                CMC7 = Path.GetFileName(imagePath).Substring(1, CMC7_LENGTH);
                Image image = Image.FromFile(imagePath);        //!! Chequear si va un try

                //guardo en memoria la imagen
                image.Save(stream, ImageFormat.Jpeg);

                return stream.ToArray();
            }
        }

        public void Initialize()
        {
            _initialized = true;
        }

        public void Close()
        {
            _initialized = false;
        }

        public bool TestScan()
        {
            return _initialized;
        }

        private string GetRandomImage(Resolution resolution)
        {
            string inputImageFolder = "";

            switch (resolution)
            {
                case Resolution.DPI_100:
                    inputImageFolder = DPI_100_FOLDER;
                    break;
                case Resolution.DPI_200:
                    inputImageFolder = DPI_200_FOLDER;
                    break;
                case Resolution.DPI_300:
                    inputImageFolder = DPI_300_FOLDER;
                    break;
            }

            string[] candidateImages = Directory.GetFiles(inputImageFolder, "*.JPG");

            if (candidateImages.Length == 0) throw new Exception($"No hay imagenes en el repositorio {inputImageFolder}");

            Random rnd = new Random(DateTime.Now.Millisecond);
            return candidateImages[rnd.Next(0, candidateImages.Length - 1)];
        }

    }
}
