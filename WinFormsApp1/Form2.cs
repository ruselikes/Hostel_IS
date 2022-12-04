using Hostel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        HostelDbContext db;
        public Form2()
        {
            InitializeComponent();
            
            db = new HostelDbContext();

            /*Manager man = new Manager { Mphone = "79048378017", Mname = "Ruslan", Msurname = "Maratkanov", Login = "admin", Password = "admin" };
            db.Managers.Add(man);
            db.SaveChanges();*/
        }


  
        private void button1_Click(object sender, EventArgs e)
        {
            var flag = false;
                var managers = db.Managers.ToList();
                foreach (Manager mng in managers)
                {
                    if (mng.Login == textBox1.Text && mng.Password == textBox2.Text)
                    {
                        this.Hide();
                        
                        

                        Form1 f1 = new Form1();
                        f1.Closed += (s, args) => this.Close();
                        f1.Show();
                        flag = true;
                        break;
                        

                    }
                

                }
            if (flag == false) {MessageBox.Show("Неправильный пароль/логин.Попробуйте снова");}

            }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
