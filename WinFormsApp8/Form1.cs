namespace WinFormsApp8
{
    public partial class Form1 : Form
    {
        dic d1 = new dic(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+Application.StartupPath+ @"\dicDb.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
        }

        void showData(string s = null)
        {
            dataGridView1.DataSource = d1.returnRec(s);
            dataGridView1.Columns[0].Width = dataGridView1.Width;

            btnEdit.Enabled = dataGridView1.Rows.Count > 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                txtTranslate.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            catch {}
        }

        private void txtEnglishWord_TextChanged(object sender, EventArgs e)
        {
            showData(txtEnglishWord.Text);
        }

        public string GetEnglishWord()
        {
            return dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
        public string GetFarsiWord()
        {
            return dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;

            frmEdit f1 = new frmEdit(this);
            f1.ShowDialog();
            showData();

            dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
        }
    }
}