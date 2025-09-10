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
            File.WriteAllText("initusers.txt", text);
        }
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

        public static void CheckPatientDetails()
        {
            Console.Clear();
            Utils.GenerateMenu("Check Patient Details");

            int id;
            Patient pat = new Patient(); 
            bool valid = false;
            while (true)
            {
                Console.Write("\nEnter the ID of the patient to check: ");
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                    foreach (User u in FileManager.users)
                    {
                        if (id == u.id && u.UserRole == Role.P)
                        {
                            valid = true;
                            pat = (Patient)u;
                            break;
                        }
                    }
                    if (valid) break;
                    Console.WriteLine("ID Not Found");
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Invalid ID: must be an int");
                }
            }
            Console.WriteLine("Details for {0}\n", pat.name);
            Utils.PatientDoctorTitle();
            Console.WriteLine(pat.ToString());

            Console.Write("\nPress any key to return to menu: ");
            Console.ReadKey();
        }

       //public static Appointment BookAppointment(Patient patient, Doctor doctor)
        // {

        //}



    }
}