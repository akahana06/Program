using System;
using System.Collections;
using System.Net;
using System.Numerics;
using static AssignmentApp.User;

namespace AssignmentApp
{
    static class FileManager
    {
        public static ArrayList users = new ArrayList();
        public static void InitialiseUsers(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] u = line.Split(',');
                if (u[0] == "Admin")
                {
                    Admin a = new Admin();
                    a.LoadUser(line);
                    users.Add(a);
                }
                else if (u[0] == "Patient")
                {
                    Patient p = new Patient();
                    p.LoadUser(line);
                    users.Add(p);
                }
                else if (u[0] == "Doctor")
                {
                    Doctor d = new Doctor();
                    d.LoadUser(line);
                    users.Add(d);
                }

            }
            sr.Close();

        }

        public static Appointment BookAppointment(Patient patient, Doctor doctor, DateTime dateTime)
        {
            return default(Appointment);
        }



    }
}