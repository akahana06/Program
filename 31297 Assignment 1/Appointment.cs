using System;

namespace AssignmentApp
{
    class Appointment
    {

        private Patient patient;
        private Doctor doctor;
        private DateTime dateTime;
        public Appointment(Patient patient, Doctor doctor, DateTime dateTime)
        {
            this.patient = patient;
            this.doctor = doctor;
            this.dateTime = dateTime;
        }

    }
}