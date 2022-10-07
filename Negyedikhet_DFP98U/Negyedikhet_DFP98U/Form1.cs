using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;


namespace Negyedikhet_DFP98U
{
    public partial class Form1 : Form
    {
        RealEstateEntities real = new RealEstateEntities();
        List<Flat> Flatties;

        Excel.Application xlAPP;
        Excel.Workbook xlWB;
        Excel.Worksheet xlShit;
        public Form1()
        {
            InitializeComponent();
            LoadData();
            CreateExcel();
        }

        private void LoadData()
        {
            Flatties = real.Flats.ToList();
        }

        private void CreateExcel()
        {
            try
            {
                xlAPP = new Excel.Application();
                xlWB = xlAPP.Workbooks.Add(Missing.Value);
                xlShit = xlWB.ActiveSheet();
                //CreateTable();
                xlAPP.Visible = true;
                xlAPP.UserControl = true;

            }
            catch ( Exception ex)
            {
                string errMsg = string.Format("Error: {0}\nLine {1}", ex.Message, ex.Source);
                MessageBox.Show(errMsg, "Error");

                xlWB.Close(false, Type.Missing, Type.Missing);
                xlAPP.Quit();
                xlWB = null;
                xlAPP = null;

            }
        }
    }
}
