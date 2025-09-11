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
            id = 0;
            password = name = email = phone = address = "";
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
                        CheckPatientAppointments();
                        break;
                    case 6:
                        AssignmentApp.Login();
                        choice = 7;
                        break;
                    case 7:
                        Console.WriteLine("Exiting System...");
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.\nPress any key to retry...");
                        Console.ReadKey();
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


        public void ListMyDetails()
        {
            Console.Clear();
            Utils.GenerateMenu("My Details");

            Utils.DoctorDetailTitle();
            Console.WriteLine(this.ToString());

            Console.Write("\nPress any key to return to menu:");
            Console.ReadKey();
        }

        public void ListMyPatients()
        {
            ArrayList patients = new ArrayList();
            
            Console.Clear();
            Utils.GenerateMenu("My Patients");

            Console.WriteLine("\nPatients assigned to {0}:", name);
            Utils.PatientDoctorTitle();
            foreach (Appointment a in appointments)
            {
                if (patients.Contains(a.Patient)) continue;
                Console.WriteLine(a.Patient.ToString());
                patients.Add(a.Patient);
            }

            Console.Write("\nPress any key to return to menu:");
            Console.ReadKey();
        }

        public void CheckPatientDetails()
        {
            FileManager.CheckPatientDetails(this);
        }

        public void CheckPatientAppointments()
        {
            Console.Clear();
            Utils.GenerateMenu("Appointments With");

            int id;
            Patient pat = new Patient();
            bool valid = false;
            while (true)
            {
                Console.Write("\nEnter the ID of the patient you would like to view appointments for: ");
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

            if (pat.doctor != this)
            {
                Console.WriteLine("{0} has no appointments booked with you.", pat.name);
            } else
            {
                Utils.AppointmentTitle();
                foreach (Appointment a in pat.appointments)
                {
                    Console.WriteLine(a.ToString());
                }
            }
            
            Console.Write("\nPress any key to return to menu: ");
            Console.ReadKey();
        }

        public new void LoadUser(string line)
        {
            base.LoadUser(line);
        }

        public override string ToString()
        {
            //"Name                | Email Address        | Phone      | Address"
            // 12345678901234567890| 123456789012345678901| 12345678901|
            string line;
            int maxName = 22;
            int maxPhone = 11;

            line = (name.Length > maxName ? name.Substring(0, maxName) : name.PadRight(maxName)) + "| ";
            line += (email.Length > maxName ? email.Substring(0, maxName) : email.PadRight(maxName)) + "| ";
            line += (phone.Length > maxPhone ? phone.Substring(0, maxPhone) : phone.PadRight(maxPhone)) + "| ";
            line += address;

            return line;
        }
        // test

        // New line

    }
}