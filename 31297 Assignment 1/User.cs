using System;
using System.Collections;

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
        public ArrayList appointments = new ArrayList();

        public enum Role
        {
            P,
            D,
            A
        }
        // upate
        public abstract void MainMenu();
        public Role UserRole { get; set; }

        public void LoadUser(string line)
        {
            string[] u = line.Split(',');
<<<<<<< Updated upstream
            id = Convert.ToInt32(u[1]);
            password = u[2];
            name = u[1];
            address = u[2];
            email = u[3];
            phone = u[4];
=======
            name = u[1];
            email = u[2];
            phone = u[3];
            address = u[4];
            password = u[5];
            id = Convert.ToInt32(u[6]); // test
>>>>>>> Stashed changes
        }

    }
}