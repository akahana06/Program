using System;

namespace AssignmentApp
{
    class Patient
    {
        private string name;
        
        public Patient(int id, string name)
        {
            this.id = id;
        }

        public int Name
        {
            get { return id; }
            set { id = value; }
        }

    }
}