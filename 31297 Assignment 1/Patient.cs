using System;
using System.Collections.Concurrent;
using System.Net;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using static AssignmentApp.User;

namespace AssignmentApp
{
    class Patient : User
    {

        public Doctor doctor = new Doctor();

        public Patient()
        {
            UserRole = Role.P;        
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
                        ListPatientDetails();
                        break;
                    case 2:
                        ListMyDoctorDetails();
                        break;
                    case 3:
                        base.ListMyAppointments();
                        break;
                    case 4:
                        BookAppointment();
                        break;
                    case 5:
                        AssignmentApp.Login();
                        return;
                    case 6:
                        Console.WriteLine("Exiting System...");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
                if (choice == 6) return;
            }
        }

        public void PrintMenu()
        {
            Console.Clear();
            Utils.GenerateMenu("Patient Menu");

            Console.WriteLine("Welcome to DOTNET Hospital Management System {0}", this.name);
            Console.WriteLine("\nPlease choose an option:");
            Console.WriteLine("1. List patient details");
            Console.WriteLine("2. List my doctor details");
            Console.WriteLine("3. List all appointments");
            Console.WriteLine("4. Book appointment");
            Console.WriteLine("5. Exit to login");
            Console.WriteLine("6. Exit System\n");
        }

        public void ListPatientDetails()
        {
            Console.Clear();
            Utils.GenerateMenu("My Details");

            Console.WriteLine("\n{0}'s Details\n", this.name);
            Console.WriteLine("Patient ID: {0}", this.id);
            Console.WriteLine("Full Name: {0}", this.name);
            Console.WriteLine("Address: {0}", this.address);
            Console.WriteLine("Email: {0}", this.email);
            Console.WriteLine("Phone: {0}", this.phone);

            Console.Write("\nPress any key to return to menu:");

            Console.ReadKey();
        }

        public void ListMyDoctorDetails()
        {
            Console.Clear();
            Utils.GenerateMenu("My Doctor");

            if (doctor == null)
            {
                Console.WriteLine("\nYou currently have no doctor. \nPlease book an appointment to view your doctor's details.");
                Console.Write("\nPress any key to return to menu:");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nYour doctor:\n");
            Utils.DoctorDetailTitle();
            Console.WriteLine(doctor.ToString());

            Console.Write("\nPress any key to return to menu:");
            Console.ReadKey();
        }



        public void BookAppointment()
        {
            Console.Clear();

            Utils.GenerateMenu("Book Appointment");
            if (doctor == null)
            {
                Console.WriteLine("\nYou are not registered with any doctor! Please choose which doctor you would like to register");
                User[] doctors = new User[5];
                int num = 1;
                foreach (User u in FileManager.users)
                {
                    if (u.UserRole == Role.D)
                    {
                        Console.WriteLine(num + " " + u.ToString());
                        doctors[num - 1] = u;
                        num++;
                    }
                }
                Console.Write("\nPlease choose a doctor: ");
                doctor = (Doctor)doctors[Convert.ToInt32(Console.ReadLine()) - 1];
            }
            Console.WriteLine("\nYou are booking a new appointment with {0}", doctor.name);
            Console.Write("Description of the appointment: ");
            string desc = Console.ReadLine();
            Appointment apt = new Appointment(this, doctor, desc);
            Console.WriteLine("\nThe appointment has been booked successfully");
            Console.Write("\nPress any key to return to menu: ");

            Console.ReadKey();
        }

        public new void LoadUser(string line)
        {
            base.LoadUser(line);
        }

        public override string ToString()
        {
            string line;
            Doctor d = doctor;
            int maxName = 20;
            int maxEMail = 21;
            int maxPhone = 11;

            line = (name.Length > maxName ? name.Substring(0, maxName) : name.PadRight(maxName)) + "| ";
            line = (d.name.Length > maxName ? d.name.Substring(0, maxName) : d.name.PadRight(maxName)) + "| ";
            line += (email.Length > maxEMail ? email.Substring(0, maxEMail) : email.PadRight(maxEMail)) + "| ";
            line += (phone.Length > maxPhone ? phone.Substring(0, maxPhone) : phone.PadRight(maxPhone)) + "| ";
            line += address;
            return line;
        }

    }
}