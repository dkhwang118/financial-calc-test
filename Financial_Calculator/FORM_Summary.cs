using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financial_Calculator
{
    public partial class FORM_Summary : Form
    {
        public FORM_Summary()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void uxButton_add_transactions_Click(object sender, EventArgs e)
        {
            FORM_add_transactions form_at = new FORM_add_transactions();
            form_at.Show();
        }
    }
}
