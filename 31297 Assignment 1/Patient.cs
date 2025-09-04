using System;
using System.Collections.Concurrent;
using System.Net;
using System.Numerics;
using System.Security.Cryptography;
using static AssignmentApp.User;

namespace AssignmentApp
{
    class Patient : User
    {

        public Doctor doctor;

        public Patient()
        {
            UserRole = Role.P;
        }

        public override void MainMenu()
        {
            int choice = 0;
            while (choice < 1 && choice > 6)
            {
                PrintMenu();
                switch (choice = Convert.ToInt32(Console.ReadKey()))
                {
                    case 1:
                        ListPatientDetails();
                        break;
                    case 2:
                        ListMyDoctorDetails();
                        break;
                    case 3:
                        ListMyAppointments();
                        break;
                    case 4:
                        BookAppointment();
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;

                }
            }
            
        }

        public void PrintMenu()
        {
            // Console.WriteLine("_________________________________________");
            // Console.WriteLine("|   DOTNET Hospital Management System   |");
            // Console.WriteLine("|---------------------------------------|");
            // Console.WriteLine("|             Patient Menu              |");
            // Console.WriteLine("|_______________________________________|");
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
            // Console.WriteLine("_________________________________________");
            // Console.WriteLine("|   DOTNET Hospital Management System   |");
            // Console.WriteLine("|---------------------------------------|");
            // Console.WriteLine("|              My Details               |");
            // Console.WriteLine("|_______________________________________|");
            Utils.GenerateMenu("My Details");

            Console.WriteLine("\n{0}'s Details\n");
            Console.WriteLine("Patient ID: {0}", this.id);
            Console.WriteLine("Full Name: {0}", this.name);
            Console.WriteLine("Address: {0}", this.address);
            Console.WriteLine("Email: {0}", this.email);
            Console.WriteLine("Phone: ", this.phone);

            Console.ReadKey();
            MainMenu();
        }

        public void ListMyDoctorDetails()
        {
            // Console.WriteLine("_________________________________________");
            // Console.WriteLine("|   DOTNET Hospital Management System   |");
            // Console.WriteLine("|---------------------------------------|");
            // Console.WriteLine("|               My Doctor               |");
            // Console.WriteLine("|_______________________________________|");
            Utils.GenerateMenu("My Doctor");

            Console.WriteLine("\nYour doctor:\n");
            Console.WriteLine("Name                | Email Address        | Phone      | Address");
            Console.WriteLine("------------------------------------------------------------------------------------");
            
        }

        public void BookAppointment()
        {
            Utils.GenerateMenu("Book Appointment");
            if (doctor == null)
            {
                Console.WriteLine("You are not registered with any doctor! Please choose which doctor you would like to register");
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
                Console.WriteLine("Please choose a doctor:");
                doctor = (Doctor)doctors[Convert.ToInt32(Console.ReadLine()) - 1];
            }
            Console.WriteLine("You are booking a new appointment with {0}", doctor.name);
            Console.WriteLine("Description of the appointment: ");
            string desc = Console.ReadLine();
            Appointment apt = new Appointment(this, doctor, desc);
            Console.WriteLine("The appointment has been booked successfully");

            Console.ReadKey();
            MainMenu();
        }

        public void ListMyAppointments()
        {
            Utils.GenerateMenu("My Appointments");
            Console.WriteLine("Appointments for {0}", this.name);
            Console.WriteLine("Doctor              | Patient           | Description");
            Console.WriteLine("---------------------------------------------------------------------");
            foreach (Appointment a in appointments)
            {
                Console.WriteLine(a.ToString());
            }

            Console.ReadKey();
            MainMenu();
        }

        public void LoadUser(string line)
        {
            base.LoadUser(line);
        }

    }
}