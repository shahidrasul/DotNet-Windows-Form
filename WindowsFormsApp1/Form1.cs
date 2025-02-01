using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class formWelcome : Form
    {
        public formWelcome()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, System.EventArgs e)
        {
            string strName = tbInput.Text.Trim();

            if (string.IsNullOrEmpty(strName))
            {
                lbNameRequired.Text = "Name should be given";
                return;
            }

            lbWelcome.Text = "Welcome " + tbInput.Text;
            btnNext.Visible = true;
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            this.Hide();

            Calculator calculator = new Calculator();
            calculator.Show();
        }

        private void btnform2_Click(object sender, System.EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
