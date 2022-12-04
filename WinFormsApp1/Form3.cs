using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WinFormsApp1;

namespace Hostel
{
    public partial class Form3 : Form
    {
        HostelDbContext db;
        public Form3()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                db = new HostelDbContext();
                Manager manager = new Manager();
                manager.Mname = regBox1.Text;
                manager.Msurname = regBox2.Text;
                manager.MmiddleName = regBox.Text;
                manager.Mphone = regBox4.Text;
                manager.Login = regBox5.Text;
                manager.Password = regBox3.Text;
                // добавляем в бд    
                db.Managers.Add(manager);
                db.SaveChanges();
                MessageBox.Show("Зарегистрирован новый менеджер!");
                this.Hide();
                /*this.Hide();
                Form2 f2 = new Form2();
                
                f2.Show();*/
            }
            catch
            {
                MessageBox.Show("Введите корректные данные!");
            }
        }
    }
}
