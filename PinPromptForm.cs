using System;
using System.Windows.Forms;

namespace MassPdfSigner
{
    public partial class PinPromptForm : Form
    {
        public string Pin
        {
            get { return txtPin.Text; }
        }

        public PinPromptForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPin.Text))
            {
                MessageBox.Show("Unesi PIN.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
