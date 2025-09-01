using System;

namespace AssignmentApp
{
    abstract class User
    {
        public int id;
        public string password;
        public string name;
        public string address;
        public string email;
        public string phone;

        public enum Role
        {
            Patient,
            Doctor,
            Admin
        }

        public abstract void MainMenu();
        public Role UserRole { get; set; }

    }
}