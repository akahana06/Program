using System;
using System.Net;
using System.Numerics;
using static AssignmentApp.User;

namespace AssignmentApp
{
    class Patient : User
    {
        
        public Patient(int id, string password, string name, string address, string email, string phone)
        {
            UserRole = Role.Doctor;

            this.id = id;
            this.password = password;
            this.name = name;
            this.address = address;
            this.email = email;
            this.phone = phone;
        }

        public int Name
        {
            get { return id; }
            set { id = value; }
        }
        public override void MainMenu()
        {
            Console.WriteLine("Hallo");
            Console.WriteLine("Halloooo");
        }

    }
}