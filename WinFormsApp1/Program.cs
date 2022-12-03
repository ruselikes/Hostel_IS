using Microsoft.VisualBasic.ApplicationServices;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            /*using (HostelDbContext db = new HostelDbContext())
            {
                Client tom = new Client {PhoneNumber = "7904837", Passport = "12345678",ClientName = "Tom",ClientSurname = "Маратканов",ClientMiddleName = "Петрович" };
                Client alice = new Client {PhoneNumber = "7904837", Passport = "12345678",ClientName = "Матня",ClientSurname = "Пчелкина",ClientMiddleName = "Викторовна" };

                // добавляем их в бд    
                db.Clients.Add(tom);
                db.Clients.Add(alice);
                db.SaveChanges();
                // получаем объекты из бд и выводим на консоль
                var clients = db.Clients.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Client c in clients)
                {
                    Console.WriteLine($"{c.ClientId}.{c.ClientName}");
                }
            }*/

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}