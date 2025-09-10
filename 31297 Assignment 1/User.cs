using System;
using System.Collections;
using System.Numerics;

namespace AssignmentApp
{
    abstract class User
    {
        public int id;
        public string password;
        public string name;
        public string email;
        public string phone;
        public string address;
        
        public ArrayList appointments = new ArrayList();

        public User()
        {
            id = 0;
            password = name = email = phone = address = "";
        }
        public enum Role
        {
            P,
            D,
            A
        }
        // upate
        public abstract void MainMenu();
        public Role UserRole { get; set; }

        public void ListMyAppointments()
        {
            Console.Clear();
            Utils.GenerateMenu("My Appointments");

            if (appointments.Count == 0)
            {
                Console.WriteLine("\nNo appointments booked");
                Console.Write("\nPress any key to return to menu:");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nAppointments for {0}", this.name);
            Utils.AppointmentTitle();
            foreach (Appointment a in appointments)
            {
                Console.WriteLine(a.ToString());
            }

            Console.Write("\nPress any key to return to menu: ");
            Console.ReadKey();
        }

        public void LoadUser(string line)
        {
            string[] u = line.Split(',');
            name = u[1];
            email = u[2];
            phone = u[3];
            address = u[4];
            password = u[5];
            id = Convert.ToInt32(u[6]); // test
        }

    }
}