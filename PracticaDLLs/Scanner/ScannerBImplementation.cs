using RoboCorp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNA
{
    public class ScannerBImplementation : BNAScanner
    {
        const string OUT_IMAGE_EXTENSION = "PNG";

        ScannerB _scanner;

        public ScannerBImplementation()
        {
            _scanner = new ScannerB();
            _scanner.Initialize();
        }

        public override void Detener()
        {
        }

        public override void Digitalizar()
        {
            string CMC7;
            byte[] image = _scanner.Scan(out CMC7);
            
            if (!Directory.Exists(this.DirDestino)) Directory.CreateDirectory(this.DirDestino);
            File.WriteAllBytes($"{this.DirDestino}\\{CMC7}.{OUT_IMAGE_EXTENSION}", image);
        }

        public override bool Test()
        {
            return _scanner.TestScan();
        }
    }
}
