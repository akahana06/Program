using System;
using System.Collections;

namespace AssignmentApp
{
    class Doctor : User
    {
        ArrayList appointments = new ArrayList();
        public Doctor(int id, string password, string name, string address, string email, string phone)
        {
            UserRole = Role.Doctor;
            
            this.id = id;
            this.password = password;
            this.name = name;   
            this.address = address; 
            this.email = email;
            this.phone = phone;
        }

        public override void MainMenu()
        {
            Console.WriteLine("Hallo");
        }

        // test



    }
}