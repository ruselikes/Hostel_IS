using System.Windows.Forms;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1

{
    public partial class Form1 : Form
    {
        HostelDbContext db;
        public Form1()
        { 
            InitializeComponent();


            db = new HostelDbContext();

            Room room = new Room { BedQty  = 8, FreeBedQty = 4,Price = 1500};
            db.Rooms.Add(room);
            db.SaveChanges();


            dataGridView1.DataSource = db.Clients.ToList();
            /*dataGridView2.DataSource = db.Rooms.ToList();*/


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

        private void button1_Click(object sender, EventArgs e)
        {
            
            Client client = new Client();
            client.ClientName = textBox1.Text;
            client.ClientSurname = textBox2.Text;
            client.ClientMiddleName = textBox3.Text;
            client.PhoneNumber = textBox4.Text;
            client.Passport = textBox5.Text;
            // добавляем в бд    
            db.Clients.Add(client);
            db.SaveChanges();
            dataGridView1.DataSource = db.Clients.ToList();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var free = Convert.ToInt32(textBox6.Text);

            var freerooms = db.Rooms.FromSqlRaw($"SELECT * FROM Room WHERE FreeBedQty >= {free}").ToList();
            dataGridView2.DataSource = freerooms;

        }
    }
}