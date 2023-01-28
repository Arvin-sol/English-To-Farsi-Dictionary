using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp8
{
    public partial class frmEdit : Form
    {
        Form1 frm1;
        public frmEdit()
        {
            InitializeComponent();
        }
        public frmEdit(Form1 x)
        {
            frm1 = x;
            InitializeComponent();
            txtEnglishWordEdit.Text = x.GetEnglishWord();
            txtFarsiWordEdit.Text = x.GetFarsiWord();
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            dic d1 = new dic(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+Application.StartupPath+ @"\dicDb.mdf;Integrated Security=True;Connect Timeout=30");
            d1.EditRec(txtFarsiWordEdit.Text, txtEnglishWordEdit.Text);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
