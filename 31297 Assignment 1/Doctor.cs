using System;
using System.Collections;
using System.Numerics;
using System.Xml.Linq;

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
            while (true)
            {
                PrintMenu();
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        ListMyDetails();
                        break;
                    case 2:
                        ListMyPatients();
                        break;
                    case 3:
                        base.ListMyAppointments();
                        break;
                    case 4:
                        CheckPatientDetails();
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
                if (choice == 7) return;
            }
        }

        public void PrintMenu()
        {
            Console.Clear();
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

        public void PatientDoctorTitle()
        {
            Console.WriteLine("\nPatient                | Doctor                | Email Address        | Phone      | Address");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
        }

        public void PatientDoctorText(Patient p)
        {
            string line;
            Doctor d = p.doctor;
            int maxName = 20;
            int maxEMail = 21;
            int maxPhone = 11;
            
            line = (p.name.Length > maxName ? p.name.Substring(0, maxName) : p.name.PadRight(maxName)) + "| ";
            line = (d.name.Length > maxName ? d.name.Substring(0, maxName) : this.name.PadRight(maxName)) + "| ";
            line += (p.email.Length > maxEMail ? name.Substring(0, maxEMail) : name.PadRight(maxEMail)) + "| ";
            line += (p.phone.Length > maxPhone ? name.Substring(0, maxPhone) : name.PadRight(maxPhone)) + "| ";
            line += p.address;
            Console.WriteLine(line);
        }

        public void ListMyDetails()
        {
            Console.Clear();
            Utils.GenerateMenu("My Details");

            Console.WriteLine("\nName                | Email Address        | Phone      | Address");
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine(this.ToString());

            Console.Write("\nPress any key to return to menu:");
            Console.ReadKey();
        }

        public void ListMyPatients()
        {
            string line;
            int maxName = 20;
            int maxEMail = 21;
            int maxPhone = 11;

            Console.Clear();
            Utils.GenerateMenu("My Patients");

            Console.WriteLine("\nPatiens assigned to {0}:", name);
            PatientDoctorTitle();
            foreach (Appointment a in appointments)
            {
                PatientDoctorText(a.Patient);
            }

            Console.Write("\nPress any key to return to menu:");
            Console.ReadKey();
        }

        public void CheckPatientDetails()
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
            PatientDoctorTitle();
            PatientDoctorText(pat);

            Console.Write("\nPress any key to return to menu: ");
            Console.ReadKey();
        }

        public void LoadUser(string line)
        {
            base.LoadUser(line);
        }

        public override string ToString()
        {
            //"Name                | Email Address        | Phone      | Address"
            // 12345678901234567890| 123456789012345678901| 12345678901|
            string line;
            

            line = (name.Length > maxName ? name.Substring(0, maxName) : name.PadRight(maxName)) + "| ";
            line += (email.Length > maxEMail ? name.Substring(0, maxEMail) : name.PadRight(maxEMail)) + "| ";
            line += (phone.Length > maxPhone ? name.Substring(0, maxPhone) : name.PadRight(maxPhone)) + "| ";
            line += address;

            return line;
        }
        // test

        // New line

    }
}