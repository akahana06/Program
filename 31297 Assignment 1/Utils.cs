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

            whitespace = -len;

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
            Console.WriteLine("\nName                | Email Address        | Phone      | Address");
            Console.WriteLine("------------------------------------------------------------------------------------");
        }

        public static void PatientDoctorTitle()
        {
            Console.WriteLine("\nPatient                | Doctor                | Email Address        | Phone      | Address");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
        }

        public static void PatientDoctorText(Patient p)
        {
            string line;
            Doctor d = p.doctor;
            int maxName = 20;
            int maxEMail = 21;
            int maxPhone = 11;

            line = (p.name.Length > maxName ? p.name.Substring(0, maxName) : p.name.PadRight(maxName)) + "| ";
            line = (d.name.Length > maxName ? d.name.Substring(0, maxName) : this.name.PadRight(maxName)) + "| ";
            line += (p.email.Length > maxEMail ? p.name.Substring(0, maxEMail) : name.PadRight(maxEMail)) + "| ";
            line += (p.phone.Length > maxPhone ? p.name.Substring(0, maxPhone) : name.PadRight(maxPhone)) + "| ";
            line += p.address;
            Console.WriteLine(line);
        }

        public static void AppointmentTitle()
        {
            Console.WriteLine("\nDoctor              | Patient           | Description");
            Console.WriteLine("---------------------------------------------------------------------");
        }
        

    }
}