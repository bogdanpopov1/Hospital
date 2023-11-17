using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Staff
{
    internal class Doctor
    {
        private string _login;
        private string _password;

        private string _department;
        public string Department { get { return _department; } set { _department = value; } }

        private string _fullName;
        public string FullName { get { return _fullName; } set { _fullName = value; } }

        private string _specialization;
        public string Specialization { get { return _specialization; } set { _specialization = value; } }

        public Doctor(string login, string password, string department, string specialization, string fullName)
        {
            _login = login;
            _password = password;
            _department = department;
            _specialization = specialization;
            FullName = fullName;
        }

        List<string> schedule = new List<string>();

        public string CheckLogin()
        {
            return _login;
        }
        public string CheckPassword()
        {
            return _password;
        }

    }
}
