using System;

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

    }
}