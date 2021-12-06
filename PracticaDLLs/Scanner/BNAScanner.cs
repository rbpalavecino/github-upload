using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BNA
{
    public enum Resolution
    {
        DPI_200,
        DPI_300
    }
    public abstract class BNAScanner
    {
        public virtual Resolution Resolucion { get; set; }
        public string DirDestino { get; set; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public abstract void Digitalizar();
        public abstract bool Test();
        public abstract void Detener();

    }

}
