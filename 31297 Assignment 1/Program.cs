using System;

namespace AssignmentApp
{
    class AssignmentApp
    {
        public static void Main(string[] args)
        {
            
            // temp login
            FileManager.WriteInitUsers();
            FileManager.InitialiseUsers("inituser.txt");
            Login();
            Console.WriteLine("Thank You!");

        }

        public static void Login()
        {
            int id;
            string pass;

            Console.Clear();
            Console.WriteLine("Debug Mode (Y/N): ");
            if (Console.ReadLine().Equals("Y"))
            {
                Console.WriteLine("Debug Enabled");
                StreamReader sr = new StreamReader("users.txt");
                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                }
                sr.Close();
            }

            Utils.GenerateMenu("Login");
            while (true)
            {
                Console.Write("\nID: ");
                try
                {
                    id = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Invalid ID: must be an int");
                }
            }


            Console.Write("Password: ");
            pass = Console.ReadLine();

            foreach (User u in FileManager.users)
            {
                Console.WriteLine(u.id);
                if (id == u.id)
                {
                    if (pass == u.password)
                    {
                        Console.WriteLine("pass: {0} | u.password: {1}", pass, u.password);
                        Console.WriteLine("Valid Credentials");
                        u.MainMenu();
                        Console.WriteLine("POST MENU");
                        return;
                    }
                }
            }
            Console.WriteLine("ID / Password Invalid: Press any key to retry");
            Console.ReadKey();
            Login();
        }


    }
}