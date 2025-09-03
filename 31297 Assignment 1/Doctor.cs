using System;
using System.Collections;

namespace AssignmentApp
{
    class Doctor : User
    {
        ArrayList appointments = new ArrayList();
        public Doctor()
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