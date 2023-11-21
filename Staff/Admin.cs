using Hospital.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Staff
{
    internal class Admin
    {
        private string _login;
        private string _password;

        private string _department;
        public string Department { get { return _department; } set { _department = value; } }

        private string _fullName;
        public string FullName { get { return _fullName; } set { _fullName = value; } }

        public Admin(string login, string password, string department, string fullName) 
        {
            _login = login;
            _password = password;
            _department = department;
            _fullName = fullName;
        }


        public string CheckLogin()
        {
            return _login;
        }
        public string CheckPassword() {
            return _password;
        }

        public string ChangePassword()
        {
            Console.WriteLine("ИЗМЕНЕНИЕ ПАРОЛЯ\n");

            Console.WriteLine("Введите текущий пароль:");
            string currentPassword = Console.ReadLine();

            while (currentPassword != _password)
            {
                Console.WriteLine("Неверный текущий пароль. Попробуйте еще раз:");
                currentPassword = Console.ReadLine();
            }

            Console.WriteLine("\nВведите новый пароль:\t");
            string newPassword = Console.ReadLine();

            Console.WriteLine("\nПовторите новый пароль:\t");
            string newPasswordCheck = Console.ReadLine();

            while (newPassword != newPasswordCheck) {
                Console.WriteLine("\nПароли не совпадают. Повторите новый пароль:");
                newPasswordCheck = Console.ReadLine();
            }

            Console.WriteLine("\nПароль успешно изменен!");
            Console.WriteLine("\nНажмите Enter, чтобы выйти.");
            Console.ReadLine();

            _password = newPassword;

            return newPassword;
        }
    }
}
