using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName;
            button1.Text = Resource1.Add;
            button2.Text = Resource1.File;
            button3.Text = Resource1.Delete;

            //listbox
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text,
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = Application.StartupPath; 
            save.Filter = "Comma Seperated Values (*.csv)|*.csv"; 
            save.DefaultExt = "csv"; 
            save.AddExtension = true;
            save.FileName = "Mentettlista.csv";
            if (save.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(save.FileName, false, Encoding.UTF8))
                {
                    sw.Write("ID");
                    sw.Write(";");
                    sw.Write("FullName");
                    sw.WriteLine();
                    foreach (var sajt in users)
                    {
                        sw.Write(sajt.ID);
                        sw.Write(";");
                        sw.WriteLine(sajt.FullName);
        
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                users.RemoveAt(listBox1.SelectedIndex);
        }
    }
}
