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

        public string ToString()
        {
            string line;
            int maxDoc = 20;
            int maxPat = 18;

            line = (doctor.name.Length > maxDoc ? doctor.name.Substring(0, maxDoc) : doctor.name.PadRight(maxDoc)) + "| ";
            line += (patient.name.Length > maxPat ? patient.name.Substring(0, maxPat) : patient.name.PadRight(maxPat)) + "| ";
            line += desc;
            return line;
        }
    }
}