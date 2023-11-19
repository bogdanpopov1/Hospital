using Hospital.Patients;
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

        public List<string> scheduleMon = new List<string>();
        public List<string> scheduleTue = new List<string>();
        public List<string> scheduleWed = new List<string>();
        public List<string> scheduleThu = new List<string>();
        public List<string> scheduleFri = new List<string>();
        public List<string> scheduleWeek = new List<string>();


        public List<string> AddMon(List<string> schedule)
        {
            this.scheduleMon = scheduleMon;
            return schedule;
        }
        public List<string> AddTue(List<string> schedule)
        {
            this.scheduleTue = scheduleTue;
            return schedule;
        }
        public List<string> AddWed(List<string> schedule)
        {
            this.scheduleWed = scheduleWed;
            return schedule;
        }
        public List<string> AddThu(List<string> schedule)
        {
            this.scheduleThu = scheduleThu;
            return schedule;
        }
        public List<string> AddFri(List<string> schedule)
        {
            this.scheduleFri = scheduleFri;
            return schedule;
        }

        public List<string> FillWeekList(List<string> scheduleMon, List<string> scheduleTue, List<string> scheduleWed, List<string> scheduleThu, List<string> scheduleFri)
        {
            this.scheduleMon = scheduleMon;
            this.scheduleTue = scheduleTue;
            this.scheduleWed = scheduleWed;
            this.scheduleThu = scheduleThu;
            this.scheduleFri = scheduleFri;

            List<string> week = new List<string>()
            {
                scheduleMon.ToString(), scheduleTue.ToString(), scheduleWed.ToString(), scheduleThu.ToString(), scheduleFri.ToString()
            };

            scheduleWeek = week;

            return scheduleWeek;

        }

        List<Patient> parientsList__AD = new List<Patient>();
        List<Patient> parientsList__CD = new List<Patient>();

        public string CheckLogin()
        {
            return _login;
        }
        public string CheckPassword()
        {
            return _password;
        }

        

        public void PrintPatientsList__AD()
        {
            foreach (Patient p in parientsList__AD)
            {
                int number = 1;
                Console.WriteLine($"{number}. Время приема: {p.ReceptionTime}\n" + $"   Данные пациента: {p.FullName} ({p.Gender})  |  {p.BirthDate}  |  {p.Policу}\n");
                number++;
            }
        }

        public void PrintPatientsList__CD()
        {
            foreach (MinorPatient p in parientsList__CD)
            {
                int number = 1;
                Console.WriteLine($"{number}. Время приема: {p.ReceptionTime}\n" + $"   Данные родителя: {p.ParentName}  |  {p.ParentPhoneNumber}\n" + $"   Данные пациента: {p.FullName} ({p.Gender})  |  {p.BirthDate}  |  {p.Policу}\n");
                number++;
            }
        }
    }
}
