using System;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace AssignmentApp
{
    class Appointment
    {

        private Patient patient;
        private Doctor doctor;
        private string desc;
        public Appointment(Patient patient, Doctor doctor, string desc)
        {
            this.patient = patient;
            this.doctor = doctor;
            this.desc = desc;
            patient.appointments.Add(this);
            doctor.appointments.Add(this);
            FileManager.appointments.Add(this);
        }

        public Patient Patient
        {
            get { return patient; }
        }

        public Doctor Doctor
        {
            get { return Doctor; }
        }

        public override string ToString()
        {
            string line;
            int maxName = 22;

            line = (doctor.name.Length > maxName ? doctor.name.Substring(0, maxName) : doctor.name.PadRight(maxName)) + "| ";
            line += (patient.name.Length > maxName ? patient.name.Substring(0, maxName) : patient.name.PadRight(maxName)) + "| ";
            line += desc;
            return line;
        }
    }
}