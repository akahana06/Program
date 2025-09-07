using System;
using System.IO;
using static System.Random;
using System.Collections;
using System.Net;
using System.Numerics;
using static AssignmentApp.User;

namespace AssignmentApp
{
    static class FileManager
    {
        public static ArrayList users = new ArrayList();
        public static ArrayList appointments = new ArrayList();
        public static void InitialiseUsers(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            // FileStream file = new FileStream("users.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Random rnd = new Random();
            File.WriteAllText("users.txt", "");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                int id = rnd.Next(10000, 100000);
                line += "," + id;
                File.AppendAllText("users.txt", line + Environment.NewLine);
                string[] u = line.Split(',');
                if (u[0] == "A")
                {
                    Admin a = new Admin();
                    a.LoadUser(line);
                    users.Add(a);
                }
                else if (u[0] == "P")
                {
                    Patient p = new Patient();
                    p.LoadUser(line);
                    users.Add(p);
                }
                else if (u[0] == "D")
                {
                    Doctor d = new Doctor();
                    d.LoadUser(line);
                    users.Add(d);
                }

            }
            sr.Close();

        }

       //public static Appointment BookAppointment(Patient patient, Doctor doctor)
       // {
            
        //}



    }
}