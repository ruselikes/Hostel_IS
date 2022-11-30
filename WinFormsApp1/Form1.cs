using System.Windows.Forms;
using System.Linq;
namespace WinFormsApp1

{
    public partial class Form1 : Form
    {
        HostelDbContext db = new HostelDbContext();
        public Form1()
        { 
            InitializeComponent();
            dataGridView1.DataSource = db.Clients.ToList();
        }
        


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }


    }
}