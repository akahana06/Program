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
            while (true)
            {
                PrintMenu();
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number.\nPress any key to retry...");
                    Console.ReadKey();
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        ListAllDoctors();
                        break;
                    case 2:
                        CheckDoctorDetails();
                        break;
                    case 3:
                        ListAllPatients();
                        break;
                    case 4:
                        CheckPatientDetails();
                        break;
                    case 5:
                        AddUser(choice);
                        break;
                    case 6:
                        AddUser(choice);
                        break;
                    case 7:
                        AssignmentApp.Login();
                        choice = 8;
                        break;
                    case 8:
                        Console.WriteLine("Exiting System...");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.\nPress any key to retry...");
                        Console.ReadKey();
                        break;
                }
                if (choice == 8) return;
            }
        }

        public void PrintMenu()
        {
            Console.Clear();
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

            Doctor doc = SearchForDoctor();
            if (doc.id == 0) return;

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
            FileManager.CheckPatientDetails(new Doctor()); // id = 0
        }

        public void AddUser(int choice)
        {
            string info = "";
            string[] input = {"", "", "", "", "" };
            User u;

            Console.Clear();
            if (choice == 5)
            {
                Utils.GenerateMenu("Add Doctor");
                Console.WriteLine("Registering a new doctor with the DOTNET Hospital Management System");
                u = new Doctor();
                info += "D,";
            }
            else
            {
                Utils.GenerateMenu("Add Patient");
                Console.WriteLine("Registering a new Patient with the DOTNET Hospital Management System");
                u = new Patient();
                info += "P,";
            }
            Console.WriteLine();
            Console.WriteLine("First Name : ");
            Console.WriteLine("Last Name  : ");
            Console.WriteLine("Email      : ");
            Console.WriteLine("Phone      : ");
            Console.WriteLine("Address    : ");

            int x = 0;
            int y = 0;
            Console.SetCursorPosition(13, 7);
            while (true) 
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                char keyChar = key.KeyChar;

                if (key.Key == ConsoleKey.Enter)
                {
                    x = 0;
                    y++;
                    if (y == 5) break;
                    Console.SetCursorPosition(13, 7 + y);
                } 
                else if (key.Key != ConsoleKey.Backspace)
                {
                    x++;
                    //if ((key.Modifiers & ConsoleModifiers.Shift) != 0)
                    input[y] += keyChar;
                    Console.Write(keyChar);
                } else
                {
                    if (x > 0)
                    {
                        x--;
                        if (input[y].Length > 1)
                        {
                            input[y] = input[y].Substring(0, input[y].Length - 1);
                        } else
                        {
                            input[y] = "";
                        }   
                        Console.CursorLeft = Console.CursorLeft - 1;
                        Console.Write(" ");
                        Console.CursorLeft = Console.CursorLeft - 1;
                    } else if (y > 0)
                    {
                        y--;
                        x = input[y].Length;
                        Console.SetCursorPosition(13 + x, 7 + y);
                    }
                }
            }
            info += input[0] + " " + input[1] + "," + input[2] + "," + input[3] + "," + input[4] + ",";
            Random rnd = new Random();
            info += rnd.Next(100000, 1000000) + ","; // random 6 digit pin
            info += rnd.Next(10000, 100000); // random 5 digit id
            Console.WriteLine("\nInfo: " + info);
            u.LoadUser(info);
            FileManager.users.Add(u);
            File.AppendAllText("users.txt", info + Environment.NewLine);

            Console.SetCursorPosition(0, 14);
            Console.WriteLine("{0} added to the system!", u.name);

            Console.Write("\nPress any key to return to menu: ");
            Console.ReadKey();
        }
        public new void LoadUser(string line)
        {
            base.LoadUser(line);
        }

    }
}