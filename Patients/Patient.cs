using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Patients
{
    internal class Patient
    {
        private string _fullName;
        public string FullName { get { return _fullName; } set { _fullName = value; } }

        private string _birthDate;
        public string BirthDate { get { return _birthDate; } set { _birthDate = value; } }

        private string _gender;
        public string Gender { get { return _gender; } set { _gender = value; } }

        private int _policy;
        public int Policу { get { return _policy; } set { _policy = value; } }

        private string _receptionDay;
        public string ReceptionDay { get { return _receptionDay; } set { _receptionDay = value; } }

        private string _receptionTime;
        public string ReceptionTime { get { return _receptionTime; } set { _receptionTime = value; } }

        private string _diagnose;
        public string Diagnose { get { return _diagnose; } set { _diagnose = value; } }

        public Patient(string fullName, string birthDate, string gender, int policу, string receptionDay, string receptionTime)
        {
            FullName = fullName;
            BirthDate = birthDate;
            Gender = gender;
            Policу = policу;
            ReceptionDay = receptionDay;
            ReceptionTime = receptionTime;
        }



    }
}
