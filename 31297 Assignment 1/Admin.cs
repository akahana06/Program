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
                        break;
                    case 8:
                        break;
                    default:
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

        public void AddUser(int choice)
        {
            string info = "";
            User u;
            if (choice == 5)
            {
                Utils.GenerateMenu("Add Doctor");
                Console.WriteLine("Registering a new doctor with the DOTNET Hospital Management System");
                u = new Doctor();
                info += "D,555,666";
            }
            else
            {
                Utils.GenerateMenu("Add Patient");
                Console.WriteLine("Registering a new Patient with the DOTNET Hospital Management System");
                u = new Patient();
                info += "P,666,777";
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
            u.LoadUser(info);
            FileManager.users.Add(u);
        }
        public void LoadUser(string line)
        {
            base.LoadUser(line);
        }

    }
}