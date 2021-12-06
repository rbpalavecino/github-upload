using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LoFiTech
{
    public class ScannerA
    {
        public enum ImageFormat { JPG, PNG }
        public enum ImageResolution { DPI_200, DPI_300 }

        const string DPI_200_FOLDER = @"..\..\..\Img_Cheques\200_DPI"; //Directory.GetCurrentDirectory() + @"..\..\Img_Cheques\200_DPI";
        const string DPI_300_FOLDER = @"..\..\..\Img_Cheques\300_DPI";  //Directory.GetCurrentDirectory() + @"..\..\Img_Cheques\300_DPI";

        public string DestinationDirectory { get; set; } =  Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public string GetStatus { get; set; }


        public string Scan(ImageFormat imageFormat, ImageResolution imageResolution)
        {
            string randomImagePath = GetRandomImage(imageResolution);
            return FileCopy(randomImagePath, DestinationDirectory, imageFormat.ToString());
        }


        public string[] MultiScan(ImageFormat format, ImageResolution resolution, int quantity)
        {
            string[] scannedImages = new string[quantity];

            for (int i = 0; i < quantity; i++)
            {
                scannedImages[i] = Scan(format, resolution);
            }

            return scannedImages;
        }


        public void Stop()
        { 
            //No hace nada
        }

        private string GetRandomImage(ImageResolution imageResolution)
        {
            string inputImageFolder = imageResolution == ImageResolution.DPI_200 ? DPI_200_FOLDER : DPI_300_FOLDER;
            string[] candidateImages = Directory.GetFiles(inputImageFolder, "*.JPG");

            if (candidateImages.Length == 0) throw new Exception($"No hay imagenes en el repositorio {inputImageFolder}");

            Random rnd = new Random(DateTime.Now.Millisecond);
            return candidateImages[rnd.Next(0, candidateImages.Length-1)];
        }


        /// <summary>
        /// Copia un archivo a un directorio determinado con la extension especificada
        /// </summary>
        private string FileCopy(string sourceFilePath, string destDir, string newExtension )
        {
            string fileName = Path.GetFileNameWithoutExtension(sourceFilePath);
            string destFilePath = $"{destDir}\\{fileName}.{newExtension}";

            if (!Directory.Exists(destDir)) Directory.CreateDirectory(destDir);
            File.Copy(sourceFilePath, destFilePath, true);

            return destFilePath;
        }

    }
}
