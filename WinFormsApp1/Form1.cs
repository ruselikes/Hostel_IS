using System.Windows.Forms;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System.Numerics;
using Hostel;
using System.Data;

namespace WinFormsApp1

{
    public partial class Form1 : Form
    {
        HostelDbContext db;
        public void GetDatafromZasClient() 
        {
            var zasandclient = db.Zaselenies.Include(c => c.Client).ToList();
            List<ZasANDClient> list = zasandclient.Select(x => new ZasANDClient
            {
                ZaselenieId = x.ZaselenieId,
                RoomId = x.RoomId,
                ClientId = x.ClientId,
                ClientName = x.Client.ClientName,
                ClientSurname = x.Client.ClientSurname,
                DataZasel = x.DataZasel,
                DataVisel = x.DataVisel,

            }).ToList();

            dataGridView5.DataSource = list;


        }
        public Form1()
        { 
            InitializeComponent();


            db = new HostelDbContext();
         

            

            /*Room room = new Room { BedQty = 10, FreeBedQty = 10,Price = 1500};
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
            var search = db.Clients.FromSqlRaw($"SELECT * FROM Client WHERE NOT EXISTS (SELECT * FROM Zaselenie WHERE Zaselenie.ClientId = Client.ClientId);").ToList();
            dataGridView3.DataSource = search;

            /*var search = db.Zaselenies.FromSqlRaw("SELECT z.ZaselenieId,c.ClientID,c.ClientSurname,c.ClientName, r.BedQty,z.DataZasel,z.DataVisel FROM Zaselenie z JOIN Client c ON z.ClientID = c.ClientID JOIN Room r z.RoomID = r.RoomID").ToList();
            ;*/
            /*dataGridView2.DataSource = db.Rooms.ToList();*/
            /*var zaslist = from z in db.Zaselenies 
                        join c in db.Clients on z.ClientId equals c.ClientId join r in db.Rooms on z.RoomId equals r.RoomId
                        select new { ZaselenieId = z.ZaselenieId, ClientID = z.ClientId, ClientSurname = c.ClientSurname, ClientName = c.ClientName, BedQty = r.BedQty, DataZasel = z.DataZasel, DataVisel = z.DataVisel };
            dataGridView4.DataSource = zaslist;*/
            /*dataGridView2.DataSource = db.Rooms.ToList();*/


            /*var search = db.Zaselenies.FromSqlRaw("SELECT z.ZaselenieId,c.ClientID,c.ClientSurname,z.RoomId, z.DataZasel,z.DataVisel FROM Zaselenie z JOIN Client c ON z.ClientID = c.ClientID ").ToList();
            dataGridView4.DataSource = search;
            dataGridView4.Columns[0].HeaderText = "ID заселения";
            dataGridView4.Columns[1].HeaderText = "ID клиента";
            dataGridView4.Columns[2].HeaderText = "Фамилия";
            //dataGridView4.Columns[3].HeaderText = "Имя";
            dataGridView4.Columns[3].HeaderText = "Room ID";
            dataGridView4.Columns[4].HeaderText = "Дата заселения";
            dataGridView4.Columns[5].HeaderText = "Дата выселения";*/
            /*c.ClientName, JOIN Room r ON z.RoomID = r.RoomID r.BedQty, */


            var zasandclient = db.Zaselenies.Include(c => c.Client).ToList();

            
            
            GetDatafromZasClient();
            dataGridView5.Columns[0].HeaderText = "ID заселения";
            dataGridView5.Columns[1].HeaderText = "ID клиента";
            dataGridView5.Columns[2].HeaderText = "Имя";
            dataGridView5.Columns[3].HeaderText = "Фамилия";
            dataGridView5.Columns[4].HeaderText = " N комнаты";
            dataGridView5.Columns[5].HeaderText = "Дата заселения";
            dataGridView5.Columns[6].HeaderText = "Дата выселения";
            /*var testquery = db.Zaselenies.FromSqlRaw("SELECT ZaselenieId,DataVisel, DataZasel, z.ClientId,c.ClientName from Zaselenie z JOIN Client c ON z.ClientID = c.ClientID").ToList();
            dataGridView5.DataSource = testquery;*/

            /* List<ZasANDClient> zasclients = new();
             foreach (ZasAndClient zc in zasclient)*/




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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }
        /// <summary>
        /// dadsdsadasd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Zaselenie zaselenie = new Zaselenie();
                zaselenie.RoomId = Convert.ToInt32(textBox6.Text);
                zaselenie.ClientId = Convert.ToInt32(textBox10.Text);
                DateTime date1 = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                zaselenie.DataZasel = date1;
                DateTime date2 = Convert.ToDateTime(dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                zaselenie.DataVisel = date2;

                //Уменьшаем количество свободных мест при заселении нового клиента
                
                db.SaveChanges();
 


                if (DateTime.Compare(date1, date2) < 0)
                {
                    // добавляем в бд    
                    db.Zaselenies.Add(zaselenie);
                    string roomid = textBox6.Text;
                    int numberOfRowUpdated = db.Database.ExecuteSqlRaw($"UPDATE Room SET FreeBedQty -=1  WHERE RoomId={roomid}");
                    db.SaveChanges();
                    MessageBox.Show("Оформление прошло успешно!");
                }
                else { MessageBox.Show("Введите корректные данные!"); }

                var search = db.Clients.FromSqlRaw($"SELECT * FROM Client WHERE NOT EXISTS (SELECT * FROM Zaselenie WHERE Zaselenie.ClientId = Client.ClientId);").ToList();
                dataGridView3.DataSource = search;
            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }



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
            try
            {
                var free = Convert.ToInt32(textBox8.Text);
                var places = 0;
                if (comboBox1.SelectedIndex == 0) { places = 10; }
                if (comboBox1.SelectedIndex == 1) { places = 5; }
                if (comboBox1.SelectedIndex == 2) { places = 2; }

                var freerooms = db.Rooms.FromSqlRaw($"SELECT * FROM Room WHERE FreeBedQty >= {free} AND BedQty = {places}").ToList();
                db.SaveChanges();
                dataGridView2.DataSource = freerooms;
                dataGridView2.Refresh();
            }
            catch { MessageBox.Show("Введите корректные данные!"); }
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
            var search = db.Clients.FromSqlRaw($"SELECT * FROM Client WHERE ClientSurname LIKE {surname} AND NOT EXISTS (SELECT * FROM Zaselenie WHERE Zaselenie.ClientId = Client.ClientId);").ToList();
            dataGridView3.DataSource = search;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            var search = db.Clients.FromSqlRaw($"SELECT * FROM Client WHERE NOT EXISTS (SELECT * FROM Zaselenie WHERE Zaselenie.ClientId = Client.ClientId);").ToList();
            dataGridView3.DataSource = search;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             textBox10.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked) { button2.Enabled = true; }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox11.Text = dataGridView5.CurrentRow.Cells[4].Value.ToString();
            textBox12.Text = dataGridView5.CurrentRow.Cells[2].Value.ToString() + " " +dataGridView5.CurrentRow.Cells[3].Value.ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            var room = textBox11.Text;
            var zasid = dataGridView5.CurrentRow.Cells[0].Value.ToString();
            int onesql = db.Database.ExecuteSqlRaw($"DELETE FROM Zaselenie WHERE ZaselenieID = {zasid}");
            int twosql = db.Database.ExecuteSqlRaw($"UPDATE Room SET FreeBedQty +=1  WHERE RoomId={room}");
            db.SaveChanges();
            GetDatafromZasClient();



        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            var client = dataGridView5.CurrentRow.Cells[0].Value.ToString();
            int sql = db.Database.ExecuteSqlRaw($"DELETE FROM Client WHERE ClientID = {client}");
            int onesql = db.Database.ExecuteSqlRaw($"DELETE FROM Zaselenie WHERE ClientId = {client}");
            int twosql = db.Database.ExecuteSqlRaw($"UPDATE Room SET FreeBedQty +=1  WHERE ClientId={client}");
            db.SaveChanges();
            GetDatafromZasClient();

        }
    }
}