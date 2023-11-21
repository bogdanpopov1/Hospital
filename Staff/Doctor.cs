using Hospital.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            _fullName = fullName;
        }

        public List<string> scheduleMon = new List<string>();
        public List<string> scheduleTue = new List<string>();
        public List<string> scheduleWed = new List<string>();
        public List<string> scheduleThu = new List<string>();
        public List<string> scheduleFri = new List<string>();

        public List<Patient> todayList = new List<Patient>();
        public List<MinorPatient> todayList__Minor = new List<MinorPatient>();
        public Queue<Patient> todayQueue = new Queue<Patient>();
        public Queue<MinorPatient> todayQueue__Minor = new Queue<MinorPatient>();
        public List<string> AddMon(List<string> schedule)
        {
            this.scheduleMon = schedule;
            return scheduleMon;
        }
        public List<string> AddTue(List<string> schedule)
        {
            this.scheduleTue = schedule;
            return scheduleTue;
        }
        public List<string> AddWed(List<string> schedule)
        {
            this.scheduleWed = schedule;
            return scheduleWed;
        }
        public List<string> AddThu(List<string> schedule)
        {
            this.scheduleThu = schedule;
            return scheduleThu;
        }
        public List<string> AddFri(List<string> schedule)
        {
            this.scheduleFri = schedule;
            return scheduleFri;
        }

        public List<Patient> patientsList__AD = new List<Patient>();
        public List<MinorPatient> patientsList__CD = new List<MinorPatient>();

        public string CheckLogin()
        {
            return _login;
        }
        public string CheckPassword()
        {
            return _password;
        }

        
        //public void PrintPatientsList__AD()
        //{
        //    foreach (Patient p in patientsList__AD)
        //    {
        //        int number = 1;
        //        Console.WriteLine($"{number}. Время приема: {p.ReceptionTime}\n" + $"   Данные пациента: {p.FullName} ({p.Gender})  |  {p.BirthDate}  |  {p.Policу}\n");
        //        number++;
        //    }
        //}

        //public void PrintPatientsList__CD()
        //{
        //    foreach (MinorPatient p in patientsList__CD)
        //    {
        //        int number = 1;
        //        Console.WriteLine($"{number}. Время приема: {p.ReceptionTime}\n" + $"   Данные родителя: {p.ParentName}  |  {p.ParentPhoneNumber}\n" + $"   Данные пациента: {p.FullName} ({p.Gender})  |  {p.BirthDate}  |  {p.Policу}\n");
        //        number++;
        //    }
        //}
    }
}
