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
                CreateTable();
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



        private void CreateTable()
        {
            string[] headers = new string[] {
                "Kód",
                "Eladó",
                "Oldal",
                "Kerület",
                "Lift",
                "Szobák száma",
                "Alapterület (m2)",
                "Ár (mFt)",
                "Négyzetméter ár (Ft/m2)"};

            for (int i = 0; i < headers.Length; i++)
            {
                xlShit.Cells[1, i + 1] = headers[i];
            }

            object[,] values = new object[Flatties.Count, headers.Length];
            int counter = 0;
            foreach (Flat f in Flatties)
            {
                values[counter, 0] = f.Code;
                values[counter, 1] = f.Vendor;
                values[counter, 2] = f.Side;
                values[counter, 3] = f.District;
                if (f.Elevator)
                {
                    values[counter, 4] = "Van";
                }
                else
                {
                    values[counter, 4] = "Nincs";
                }
                values[counter, 5] = f.NumberOfRooms;
                values[counter, 6] = f.FloorArea;
                values[counter, 7] = f.Price;
                values[counter, 8] = "="+GetCell(counter+2, 8)+"/"+GetCell(counter+2, 7)+"*1000000";
                counter++;

            }

            xlShit.get_Range(
             GetCell(2, 1),
             GetCell(1 + values.GetLength(0), values.GetLength(1))).Value2 = values;
        }

        private string GetCell(int x, int y)
        {
            string ExcelCoordinate = "";
            int dividend = y;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ExcelCoordinate = Convert.ToChar(65 + modulo).ToString() + ExcelCoordinate;
                dividend = (int)((dividend - modulo) / 26);
            }
            ExcelCoordinate += x.ToString();

            return ExcelCoordinate;
        }
    }
}
