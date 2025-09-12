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
        //public static ArrayList appointments = new ArrayList();

        public static void WriteInitUsers()
        {
            string text = "";
            text += "A,Admin,admin@gmail.com,0400000000,1 Admin Ave,ADMIN\n";
            text += "D,Dr Wilks,drwilks@gmail.com,0401987654,5 Medical Dr,DOCTOR\n";
            text += "D,Dr Bones,drbones@gmail.com,0409123456,8 Xray Dr,DOCTOR\n";
            text += "D,Dr Life,drlife@gmail.com,0405789123,57 Femur Dr,DOCTOR\n";
            text += "D,Dr Joeseph Longnameington,drjoesephlongnameington@gmail.com,0401987654,867 Intestine Dr,DOCTOR\n";
            text += "P,George Washington,georgewashington@gmail.com,0408354765,1 President St,PATIENT\n";
            text += "P,Mark Leppington,markleppington@gmail.com,0402564926,85 Pittwater St,PATIENT\n";
            text += "P,Patient Zero,patientzero@gmail.com,0400000000,1 Death St,PATIENT";
            File.WriteAllText("inituser.txt", text);
        }
        public static void InitialiseUsers(string filename)
        {
            StreamReader sr = new StreamReader(filename);
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

        public static void LoadData(string userFile, string aptFile)
        {
            StreamReader userSR = new StreamReader(userFile);
            while (!userSR.EndOfStream)
            {
                string line = userSR.ReadLine();
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
            userSR.Close();

            StreamReader aptSR = new StreamReader(aptFile);
            while (!aptSR.EndOfStream)
            {
                string line = aptSR.ReadLine();
                string[] details = line.Split(",");
                Doctor doc = FindDoctor(details[0]);
                Patient pat = FindPatient(details[1]);
                string desc = details[2];

                if (doc.id == 0 || pat.id == 0)
                {
                    continue;
                }

                Appointment(doc, pat, desc);
            }
            aptSR.Close();
        }

        public static Doctor SearchForDoctor()
        {
            int id;
            Doctor doc = new Doctor();
            while (true)
            {
                Console.WriteLine("\nPlease enter the ID of the doctor who's details you are checking. (Press esc to exit)");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Exiting...");
                    return new Doctor();
                }
                try
                {
                    Console.Write(keyInfo.KeyChar);
                    id = Convert.ToInt32(keyInfo.KeyChar + Console.ReadLine());
                    doc = FindDoctor(id);
                    if (doc.id != 0) break;
                    Console.WriteLine("ID Not Found");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Invalid ID: must be an int");
                }
            }
            return doc;
        }

        public static Doctor FindDoctor(int id)
        {
            foreach (User u in FileManager.users)
            {
                if (id == u.id && u.UserRole == Role.D)
                {
                    return (Doctor)u;
                }
            }
            return new Doctor();
        }

        public static Patient SearchForPatient()
        {
            int id;
            Patient pat = new Patient();
            while (true)
            {
                Console.WriteLine("\nPlease enter the ID of the patient who's details you are checking. (Press esc to exit)");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Exiting...");
                    return new Patient();
                }
                try
                {
                    Console.Write(keyInfo.KeyChar);
                    id = Convert.ToInt32(keyInfo.KeyChar + Console.ReadLine());
                    pat = FindPatient(id);
                    if (pat.id != 0) break;
                    Console.WriteLine("ID Not Found");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Invalid ID: must be an int");
                }
            }
            return pat;
        }

        public static Patient FindPatient(int id)
        {
            foreach (User u in FileManager.users)
            {
                if (id == u.id && u.UserRole == Role.P)
                {
                    return (Patient)u;
                }
            }
            return new Patient();
        }

        public static void CheckPatientDetails(Doctor d)
        {
            Console.Clear();
            Utils.GenerateMenu("Check Patient Details");

            Patient pat = SearchForPatient();
            if (pat.id == 0) return;

            if (pat.doctor != d && d.id != 0) // If accessed through Admin, id = 0
            {
                Console.WriteLine("You are not {0}'s Doctor", pat.name);
            } else
            {
                Console.WriteLine("\nDetails for {0}", pat.name);
                Utils.PatientDoctorTitle();
                Console.WriteLine(pat.ToString());
            }

            Console.Write("\nPress any key to return to menu: ");
            Console.ReadKey();
        }

       //public static Appointment BookAppointment(Patient patient, Doctor doctor)
        // {

        //}



    }
}