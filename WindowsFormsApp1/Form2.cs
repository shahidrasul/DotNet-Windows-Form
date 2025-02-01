using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    enum Days { Sunday, Monday }
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            List<string> lstDays = new List<string> { "Monday", "Tuesday", "Wednesday" };

            foreach (var item in lstDays)
            {
                lbDays.Items.Add(item);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
        }
    }
}
