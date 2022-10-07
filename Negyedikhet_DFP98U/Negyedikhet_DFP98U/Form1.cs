using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negyedikhet_DFP98U
{
    public partial class Form1 : Form
    {
        RealEstateEntities real = new RealEstateEntities();
        List<Flat> Flatties;
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            Flatties = real.Flats.ToList();
        }
    }
}
