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

        private string _policy;
        public string Policу { get { return _policy; } set { _policy = value; } }

        private string _receptionDay;
        public string ReceptionDay { get { return _receptionDay; } set { _receptionDay = value; } }

        private string _receptionTime;
        public string ReceptionTime { get { return _receptionTime; } set { _receptionTime = value; } }

        private string _diagnose;
        public string Diagnose { get { return _diagnose; } set { _diagnose = value; } }

        public Patient(string fullName, string birthDate, string gender, string policу, string receptionDay, string receptionTime)
        {
            _fullName = fullName;
            _birthDate = birthDate;
            _gender = gender;
            _policy = policу;
            _receptionDay = receptionDay;
            _receptionTime = receptionTime;
        }



    }
}
