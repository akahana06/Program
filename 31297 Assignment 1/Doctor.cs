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
        }

        public override void MainMenu()
        {
            Console.WriteLine("Hallo");
            Console.WriteLine("Halloooo");
        }

        public void LoadUser(string line)
        {
            base.LoadUser(line);
        }

        // test

        // New line

    }
}