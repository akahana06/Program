using System;
using System.Net;
using System.Numerics;
using static AssignmentApp.User;

namespace AssignmentApp
{
    class Admin : User
    {

        public Admin()
        {
            UserRole = Role.Admin;
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

    }
}