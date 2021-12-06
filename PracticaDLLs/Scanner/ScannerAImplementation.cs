using LoFiTech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNA
{
    public class ScannerAImplementation : BNAScanner
    {
        ScannerA _scanner;

        public ScannerAImplementation()
        {
            _scanner = new ScannerA();
        }

        public override void Detener()
        {
            _scanner.Stop();
        }

        public override void Digitalizar()
        {
            _scanner.Scan(ScannerA.ImageFormat.PNG, ScannerA.ImageResolution.DPI_200);  //!!!!
        }

        public override bool Test()
        {
            throw new NotImplementedException();
        }
    }
}
