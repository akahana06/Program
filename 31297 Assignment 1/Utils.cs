using System;
using System.CodeDom.Compiler;

namespace AssignmentApp
{
    class Utils
    {
        public static string GenerateUsers()
        {

            return "users.txt";
        }



        public static void GenerateMenu(string txt)
        {
            int whitespace = 39;
            int len = txt.Length;

            whitespace -= len;

            string line = "|";
            for (int i = 0; i < whitespace / 2; i++)
            {
                line += " ";
            }
            line += txt;
            for (int i = 0; i < whitespace / 2; i++)
            {
                line += " ";
            }
            if (whitespace % 2 != 0) line += " ";
            line += "|";
            Console.WriteLine("_________________________________________");
            Console.WriteLine("|   DOTNET Hospital Management System   |");
            Console.WriteLine("|---------------------------------------|");
            Console.WriteLine(line);
            Console.WriteLine("|_______________________________________|");
        }

        public static void DoctorDetailTitle()
        {
            Console.WriteLine("\nName                  | Email Address         | Phone      | Address");
            Console.WriteLine("------------------------------------------------------------------------------------");
        }

        public static void PatientDoctorTitle()
        {
            Console.WriteLine("\nPatient               | Doctor                | Email Address         | Phone      | Address");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
        }

        public static void AppointmentTitle()
        {
            Console.WriteLine("\nDoctor                | Patient               | Description");
            Console.WriteLine("---------------------------------------------------------------------");
        }
        

    }
}