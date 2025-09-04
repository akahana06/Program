using System;
using System.Collections;

namespace AssignmentApp
{
    class Doctor : User
    {
        public Doctor()
        {
            UserRole = Role.D;
        }

        public override void MainMenu()
        {
            int choice = 0;
            while (choice < 1 && choice > 7)
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
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    default:
                        break;
                }
            }
        }

        public void PrintMenu()
        {
            Utils.GenerateMenu("Doctor Menu");

            Console.WriteLine("Welcome to DOTNET Hospital Management System {0}", this.name);
            Console.WriteLine("\nPlease choose an option:");
            Console.WriteLine("1. List doctor details");
            Console.WriteLine("2. List patients");
            Console.WriteLine("3. List appointments");
            Console.WriteLine("4. Check particular patient");
            Console.WriteLine("5. List appointments with patient");
            Console.WriteLine("6. Logout");
            Console.WriteLine("7. Exit\n");
        }

        public void LoadUser(string line)
        {
            base.LoadUser(line);
        }

        // test

        // New line

    }
}