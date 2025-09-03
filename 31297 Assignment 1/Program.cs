using System;

namespace AssignmentApp
{
    class AssignmentApp
    {
        static void Main(string[] args)
        {
            // If user found

            // temp login
            FileManager.InitialiseUsers("users.txt");
            Console.WriteLine("_________________________________________");
            Console.WriteLine("|   DOTNET Hospital Management System   |");
            Console.WriteLine("|---------------------------------------|");
            Console.WriteLine("|                 Login                 |");
            Console.WriteLine("|_______________________________________|");

            Console.WriteLine("\nID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nPassword: ");
            string pass = Console.ReadLine();

            foreach (User u in FileManager.users)
            {
                if (id == u.id)
                {
                    if (pass == u.password)
                    {
                        u.MainMenu();
                    }
                }
            }

        }

        
    }
}