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

          /*  Room room = new Room { BedQty = 10, FreeBedQty = 10,Price = 1500};
            Room room1 = new Room { BedQty = 10, FreeBedQty = 10, Price = 1500 };
            Room room2 = new Room { BedQty = 10, FreeBedQty = 10, Price = 1500 };
            Room room3 = new Room { BedQty = 10, FreeBedQty = 10, Price = 1500 };
            Room room4 = new Room { BedQty = 5, FreeBedQty = 5, Price = 3000 };
            Room room5 = new Room { BedQty = 5, FreeBedQty = 5, Price = 3000 };
            Room room6 = new Room { BedQty = 5, FreeBedQty = 5, Price = 3000 };
            Room room7 = new Room { BedQty = 2, FreeBedQty = 2, Price = 4500 };
            Room room8 = new Room { BedQty = 2, FreeBedQty = 2, Price = 4500 };
            db.Rooms.AddRange(room, room1, room2, room3, room4, room5, room6, room7, room8);*/
            /*var rooms = db.Rooms.ToList();
            foreach (Room r in rooms)
            {
                db.Rooms.Remove(r);
            }*/
           

            db.SaveChanges();

            button2.Enabled = false;
            dataGridView1.DataSource = db.Clients.ToList();
            dataGridView2.DataSource = db.Rooms.ToList();
            dataGridView3.DataSource = db.Clients.ToList();
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
            // добавл€ем в бд    
            db.Clients.Add(client);
            db.SaveChanges();
            dataGridView1.DataSource = db.Clients.ToList();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Zaselenie zaselenie = new Zaselenie();
            zaselenie.RoomId = Convert.ToInt32(textBox6.Text);
            zaselenie.ClientId = Convert.ToInt32(textBox10.Text);
            DateTime date1 = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            zaselenie.DataZasel = date1;
            DateTime date2 = Convert.ToDateTime(dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            zaselenie.DataVisel = date2;


            if (DateTime.Compare(date1, date2) < 0)
            {
                // добавл€ем в бд    
                db.Zaselenies.Add(zaselenie);
                db.SaveChanges();
                MessageBox.Show("ќформление прошло успешно!");
            }
            else { MessageBox.Show("¬ведите корректные данные!"); }
            
            
            /*
                        var free = Convert.ToInt32(textBox6.Text);

                        var freerooms = db.Rooms.FromSqlRaw($"SELECT * FROM Room WHERE FreeBedQty >= {free}").ToList();
                        dataGridView2.DataSource = freerooms;*/

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Clients.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var surname = "'%"+textBox7.Text + "%'"; 
            
            //var search = db.Rooms.FromSqlRaw($"SELECT * FROM Client WHERE ClientSurname = {surname}").ToList();
            var search = db.Clients.FromSqlRaw($"SELECT * FROM Client WHERE ClientSurname LIKE {surname}").ToList();
            dataGridView1.DataSource = search;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var free = Convert.ToInt32(textBox8.Text);
            var places = 0;
            if(comboBox1.SelectedIndex == 0) { places = 10; }
            if(comboBox1.SelectedIndex == 1) { places = 5; }
            if(comboBox1.SelectedIndex == 2) { places = 2; }
            var freerooms = db.Rooms.FromSqlRaw($"SELECT * FROM Room WHERE FreeBedQty >= {free} AND BedQty = {places}").ToList();
            dataGridView2.DataSource = freerooms;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var surname = "'%" + textBox9.Text + "%'";
            var search = db.Clients.FromSqlRaw($"SELECT * FROM Client WHERE ClientSurname LIKE {surname}").ToList();
            dataGridView3.DataSource = search;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = db.Clients.ToList();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             textBox10.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked) { button2.Enabled = true; }
            
        }
    }
}