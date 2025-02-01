using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string strValue1 = tbValue1.Text.Trim();
            string strValue2 = tbValue2.Text.Trim();

            if (string.IsNullOrEmpty(strValue1))
            {
                lbStatus.Text = "Value 1 should be given";
                return;
            }

            if (string.IsNullOrEmpty(strValue2))
            {
                lbStatus.Text = "Value 2 should be given";
                return;
            }

            if(!int.TryParse(strValue1, out int val1))
            {
                lbStatus.Text = "Value 1 should be digit";
                return;
            }

            if (!int.TryParse(strValue2, out int val2))
            {
                lbStatus.Text = "Value 2 should be digit";
                return;
            }

            lbResult.Text = (val1 + val2).ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {

        }
    }
}
