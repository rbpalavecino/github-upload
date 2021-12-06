using LoFiTech;
using RoboCorp;
using System;

using BNA;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaDLLs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(DateTime.Now.Millisecond.ToString());
            ScannerA scannerA = new ScannerA();
            scannerA.DestinationDirectory = @"C:\Temp\SalidaScannerA";
            //string salida = scannerA.Scan(ScannerA.ImageFormat.JPG, ScannerA.ImageResolution.DPI_300);
            string[] salida = scannerA.MultiScan(ScannerA.ImageFormat.JPG, ScannerA.ImageResolution.DPI_300, 4);

            MessageBox.Show(string.Join("|", salida));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(DateTime.Now.Millisecond.ToString());
            ScannerB scannerB = new ScannerB();
            scannerB.Initialize();

            string CMC7;
            byte[] salida = scannerB.Scan(out CMC7);

            MessageBox.Show(CMC7);
            MessageBox.Show(Encoding.UTF8.GetString(salida, 0, salida.Length));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ScannerBImplementation scanner = new ScannerBImplementation();
            scanner.DirDestino = @"C:\Temp\SalidaScannerBImple";
            scanner.Digitalizar();

        }
    }
}
