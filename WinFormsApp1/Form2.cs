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

            Manager man = new Manager{ Mphone = "79048378017", Mname = "Ruslan", Msurname = "Maratkanov", Login = "admin" , Password = "admin" };
            db.Managers.Add(man);
            db.SaveChanges();
        }


  
        private void button1_Click(object sender, EventArgs e)
        {
            var managers = db.Managers.ToList();
            foreach (Manager mng in managers)
            {
                if (mng.Login == textBox1.Text && mng.Password == textBox2.Text) { }

            }
        }
    }
}
