using System;
using System.Net;
using System.Numerics;
using static AssignmentApp.User;

namespace AssignmentApp
{
    static class FileManager
    {
        private ArrayList<User> users = new ArrayList<User>();
        public string InitialiseUsers(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream) 
            {
                string line = sr.ReadLine();
                if (u[0] == "Admin")
                {
                    Admin a = new Admin();
                    a.LoadUser(line);
                    users.Add(a);
                }

            }

        }

    }
}