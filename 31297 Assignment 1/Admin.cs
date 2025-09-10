using System;
using System.Net;
using System.Numerics;
using System.Security.Cryptography;
using static AssignmentApp.User;

namespace AssignmentApp
{
    class Admin : User
    {

        public Admin()
        {
            UserRole = Role.A;
        }

        public override void MainMenu()
        {
            int choice = 0;
            while (choice < 1 && choice > 8)
            {
                PrintMenu();
                switch (choice = Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        ListAllDoctors();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        AddUser(choice);
                        break;
                    case 6:
                        AddUser(choice);
                        break;
                    case 7:
                        AssignmentApp.Login();
                        break;
                    case 8:
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }

        public void PrintMenu()
        {
            Utils.GenerateMenu("Administrator Menu");

            Console.WriteLine("Welcome to DOTNET Hospital Management System {0}", this.name);
            Console.WriteLine("\nPlease choose an option:");
            Console.WriteLine("1. List all doctors");
            Console.WriteLine("2. Check doctor details");
            Console.WriteLine("3. List all patients");
            Console.WriteLine("4. Check patient details");
            Console.WriteLine("5. Add doctor");
            Console.WriteLine("6. Add patient");
            Console.WriteLine("7. Logout");
            Console.WriteLine("8. Exit\n");
        }

        public void ListAllDoctors()
        {
            Console.Clear();
            Utils.GenerateMenu("All Doctors");

            Console.WriteLine("\nAll doctors registered to the DOTNET Hospital Management System");

            Utils.DoctorDetailTitle();
            foreach (User u in FileManager.users)
            {
                if (u.UserRole == Role.D)
                {
                    Console.WriteLine(u.ToString());
                }
            }

            Console.WriteLine("\nPress any key to return to menu: ");

            Console.ReadKey();
        }

        public void CheckDoctorDetails()
        {
            Console.Clear();
            Utils.GenerateMenu("Doctor Details");

            
            int id;
            Doctor doc = new Doctor(); 
            bool valid = false;
            while (true)
            {
                Console.WriteLine("\nPlease enter the ID of the doctor who's details you are checking.");
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                    foreach (User u in FileManager.users)
                    {
                        if (id == u.id && u.UserRole == Role.D)
                        {
                            valid = true;
                            doc = (Doctor)u;
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
            Console.WriteLine("Details for {0}\n", doc.name);
            Utils.DoctorDetailTitle();
            Console.WriteLine(doc.ToString());

            Console.Write("\nPress any key to return to menu: ");
            Console.ReadKey();
        }

        public void ListAllPatients()
        {
            Console.Clear();
            Utils.GenerateMenu("All Patients");

            Console.WriteLine("\nAll patients registered to the DOTNET Hospital Management System");

            Utils.PatientDoctorTitle();
            foreach (User u in FileManager.users)
            {
                if (u.UserRole == Role.P)
                {
                    Console.WriteLine(u.ToString());
                }
            }

            Console.WriteLine("\nPress any key to return to menu: ");

            Console.ReadKey();
        }

        public void CheckPatientDetails()
        {
            FileManager.CheckPatientDetails();
        }

        public void AddUser(int choice)
        {
            string info = "";
            User u;
            if (choice == 5)
            {
                Utils.GenerateMenu("Add Doctor");
                Console.WriteLine("Registering a new doctor with the DOTNET Hospital Management System");
                u = new Doctor();
                info += "D";
            }
            else
            {
                Utils.GenerateMenu("Add Patient");
                Console.WriteLine("Registering a new Patient with the DOTNET Hospital Management System");
                u = new Patient();
                info += "P";
            }
            Console.WriteLine("First Name: ");
            info += Console.ReadLine() + " ";
            Console.WriteLine("Last Name: ");
            info += Console.ReadLine() + ",";
            Console.WriteLine("Email: ");
            info += Console.ReadLine() + ",";
            Console.WriteLine("Phone: ");
            info += Console.ReadLine() + ",";
            Console.WriteLine("Address: ");
            info += Console.ReadLine();

            Random rnd = new Random();
            info += rnd.Next(100000, 1000000) + ","; // random 6 digit pin
            info += rnd.Next(10000, 100000); // random 5 digit id
            u.LoadUser(info);
            FileManager.users.Add(u);
        }
        public new void LoadUser(string line)
        {
            base.LoadUser(line);
        }

    }
}