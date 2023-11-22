using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Patients
{
    internal class MinorPatient : Patient
    {
        private string _parentName;
        public string ParentName { get { return _parentName; } set { _parentName = value; } }

        private string _parentPhoneNumber;
        public string ParentPhoneNumber { get { return _parentPhoneNumber; } set { _parentPhoneNumber = value; } }

        public MinorPatient(string parentName, string parentPhoneNumber, string fullName, string birthDate, string gender, string policу, string receptionDay, string receptionTime) : base(fullName, birthDate, gender, policу, receptionDay, receptionTime)
        {
            _parentName = parentName;
            _parentPhoneNumber = parentPhoneNumber;
        }
    }
}
