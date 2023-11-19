﻿using Hospital.Staff;
using Hospital.Patients;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

//"adminAdultDepartment", "adultDepartment2023"
Admin admin__AdultDepartment = new Admin("1", "1", "Взрослое отделение", "Никотяй Игорь Андреевич");
Admin admin__ChildrenDepartment = new Admin("2", "2", "Детское отделение", "Чумаков Данил Дмитриевич");


List<Doctor> doctorsList__AdultDepartment = new List<Doctor>()
{
    //new Doctor("2", "2938483", "adult", "terapevt", "zhopa kota"),
    //new Doctor("3", "2938483", "adult", "terapevt", "zhopa kota")
};

List<Doctor> doctorsList__ChildrenDepartment = new List<Doctor>()
{

};

bool trigger1 = true;
bool trigger2 = true;
string checkUser = null;

Console.WriteLine("Добро пожаловать в нашу больницу!\n");

while (trigger1)
{
    Console.WriteLine("Что бы Вы хотели сделать?\n" + "1. Войти как админ.\n" + "2. Войти как врач.\n" + "3. Записаться на приём.\n" + "4. Выйти из приложения.\n");

    Console.Write("Выберите действие: ");
    int actionStart = Convert.ToInt32(Console.ReadLine());

    trigger2 = true;

    switch (actionStart)
    {
        case 1:
            Console.Clear();

            while (trigger2)
            {

                checkUser = null;

                checkUser = SignInAdmin(admin__AdultDepartment, admin__ChildrenDepartment, checkUser);

                if (checkUser == "adult")
                {
                    Console.Clear();
                    trigger2 = AdminAccount(admin__AdultDepartment, doctorsList__AdultDepartment, trigger2);
                }
                else if (checkUser == "children")
                {
                    Console.Clear();
                    trigger2 = AdminAccount(admin__ChildrenDepartment, doctorsList__ChildrenDepartment, trigger2);
                }
                else
                {
                    Console.Clear();
                }

            }

            break;

        case 2:
            Console.Clear();

            if (doctorsList__AdultDepartment.Count > 0 || doctorsList__ChildrenDepartment.Count > 0)
            {
                while (trigger2)
                {
                    trigger2 = DoctorAccount(SignInDoctor(doctorsList__AdultDepartment, doctorsList__ChildrenDepartment), trigger2);
                }
                
            }
            else
            {
                Console.WriteLine("В базе данных больницы нет ни одного врача. Обратитесь к администратору Вашего отделения для добавления Вас в список врачей.");
                Console.WriteLine("\nНажмите Enter, чтобы выйти.");
                Console.ReadLine();
            }

            Console.Clear();

            break;

        case 3:
            Console.WriteLine();

            Console.Clear();
            break;

        case 4:
            Console.Clear();
            Console.WriteLine("Будьте здоровы!");
            trigger1 = false;
            break;
    }

}



string SignInAdmin(Admin adminAdult, Admin adminChildren, string checkUser)
{
    Console.Clear();

    Console.WriteLine("ВХОД ОТ ИМЕНИ АДМИНИСТРАТОРА\n");

    Console.WriteLine("Введите логин:\t");
    string login = Console.ReadLine();
    string checkLogin__AdultDepartment = adminAdult.CheckLogin();
    string checkLogin__ChildrenDepartment = adminChildren.CheckLogin();

    while (login != checkLogin__AdultDepartment && login != checkLogin__ChildrenDepartment)
    {
        Console.WriteLine("Неверный логин! Попробуйте ещё раз:\t");
        login = Console.ReadLine();
    }

    Console.WriteLine("Введите пароль:\t");
    string password = Console.ReadLine();
    string checkPassword__AdultDepartment = adminAdult.CheckPassword();
    string checkPassword__ChildrenDepartment = adminChildren.CheckPassword();

    while (password != checkPassword__AdultDepartment && password != checkPassword__ChildrenDepartment)
    {
        Console.WriteLine("Неверный пароль! Попробуйте ещё раз:\t");
        password = Console.ReadLine();
    }

    if (login == checkLogin__AdultDepartment && password == checkPassword__AdultDepartment)
    {
        return "adult";
    }
    else if (login == checkLogin__ChildrenDepartment && password == checkPassword__ChildrenDepartment)
    {
        return "children";
    }
    else
    {
        Console.WriteLine("\nНеверно введен логин или пароль. Для того чтобы попробовать войти еще раз, нажмите Enter.");
        Console.ReadLine();
        return "error";
    }
}

Doctor SignInDoctor(List<Doctor> doctorsList__AD, List<Doctor> doctorsList__CD)
{
    Console.Clear();

    Console.WriteLine("ВХОД ОТ ИМЕНИ ВРАЧА\n");

    string login = null;
    string password = null;
    string checkLogin = null;
    string checkPassword = null;
    bool trigger1 = true;
    bool trigger2 = true;

    while (trigger1)
    {
        Console.WriteLine("Введите логин:\t");
        login = Console.ReadLine();

        trigger2 = true;

        while (trigger2)
        {
            foreach (Doctor doctor in doctorsList__AD)
            {
                checkLogin = doctor.CheckLogin();

                if (login == checkLogin)
                {
                    checkPassword = doctor.CheckPassword();
                }

            }

            foreach (Doctor doctor in doctorsList__CD)
            {
                checkLogin = doctor.CheckLogin();

                if (login == checkLogin)
                {
                    checkPassword = doctor.CheckPassword();
                }

            }

            if (checkPassword == null)
            {
                Console.Clear();

                Console.WriteLine("В базе данных больницы нет врача с таким логином. Попробуйте войти еще раз. Если ошибка повторится, обратитесь к администратору Вашего отделения для уточнения информации.");

                Console.Clear();

            } else
            {
                trigger1 = false;
            }
            trigger2 = false;
        }
    }

    bool trigger3 = true;

    while (trigger3)
    {
        Console.WriteLine("Введите пароль:\t");
        password = Console.ReadLine();

        if (password != checkPassword)
        {
            Console.WriteLine("Неверный пароль! Попробуйте ещё раз:\t");
        } else
        {
            trigger3 = false;
        }

    }

    Doctor doctor1 = null;
    Doctor doctor2 = null;

    foreach (Doctor doctor in doctorsList__AD)
    {
        doctor1 = doctorsList__AD.Find(doctor => doctor.CheckLogin() == login);
    }

    foreach (Doctor doctor in doctorsList__CD)
    {
        doctor2 = doctorsList__CD.Find(doctor => doctor.CheckLogin() == login);
    }

    if (doctor1 != null)
    {
        return doctor1;
    } else
    {
        return doctor2;
    }
}



//ДЕЙСТВИЯ В АККАУНТЕ АДМИНИСТРАТОРА

bool AdminAccount(Admin admin, List<Doctor> doctorsList, bool trigger2)
{
    while (trigger2 != false)
    {
        Console.Clear();

        Console.WriteLine(admin.FullName.ToUpper() + "\n");
        Console.WriteLine("Что бы Вы хотели сделать?\n" + "1. Посмотреть список врачей.\n" + "2. Составить расписание приема врачей.\n" + "3. Добавить врача.\n" + "4. Удалить врача.\n" + "5. Поменять пароль.\n" + "6. Выйти из аккаунта.\n");

        Console.Write("Выберите действие: ");
        int actionAdmin = Convert.ToInt32(Console.ReadLine());

        switch (actionAdmin)
        {
            case 1:
                Console.Clear();

                ViewDoctorsList(admin, doctorsList);

                break;

            case 2:
                string login = null;
                int number = 1;

                if (doctorsList.Count > 0)
                {
                    Console.Clear();
                    Console.WriteLine("СОСТАВЛЕНИЕ РАСПИСАНИЯ ПРИЕМА\n");

                    Console.WriteLine("Список врачей Вашего отделения:\n");

                    foreach (Doctor d in doctorsList)
                    {
                        login = d.CheckLogin();
                        Console.WriteLine($"{number}. {login}  |  {d.FullName}  |  {d.Department}  |  {d.Specialization}");
                        number++;
                    }

                    Console.Write("\nВыберите врача для добавления расписания приема. Укажите его номер в списке: ");
                    int doctorNumber = Convert.ToInt32(Console.ReadLine()) - 1;

                    Doctor specificDoctor = doctorsList[doctorNumber];

                    CreateSchedule(specificDoctor, doctorsList, admin);

                    break;
                }
                else
                {
                    AddDoctor(admin, doctorsList);
                }

                break;

            case 3:
                Console.Clear();

                if (admin.Department == "Взрослое отделение")
                {
                    Doctor doctor = CreateDoctor__AdultDepartment();
                    doctorsList.Add(doctor);
                }
                else if (admin.Department == "Детское отделение")
                {
                    Doctor doctor = CreateDoctor__ChildrenDepartment();
                    doctorsList.Add(doctor);
                }

                break;

            case 4:
                Console.Clear();

                if (doctorsList.Count > 0)
                {
                    number = 1;
                    login = null;

                    Console.WriteLine("Список врачей Вашего отделения:\n");

                    foreach (Doctor d in doctorsList)
                    {
                        login = d.CheckLogin();
                        Console.WriteLine($"{number}. {login}  |  {d.FullName}  |  {d.Department}  |  {d.Specialization}");
                        number++;
                    }

                    Console.Write("\nВыберите врача, которого хотели бы удалить. Укажите его номер в списке: ");
                    int doctorNumber = Convert.ToInt32(Console.ReadLine()) - 1;

                    doctorsList.RemoveAt(doctorNumber);

                    Console.Clear();
                    Console.WriteLine("Врач успешно удален из списка!");
                    Console.WriteLine("\nНажмите Enter, чтобы выйти.");
                    Console.ReadLine();

                }
                else
                {
                    AddDoctor(admin, doctorsList);
                }
                break;

            case 5:
                Console.Clear();
                admin.ChangePassword();
                break;

            case 6:
                trigger2 = false;
                Console.Clear();
                break;

        }
    }

    return false;
}


void ViewDoctorsList(Admin admin, List<Doctor> doctorsList)
{
    if (doctorsList.Count > 0)
    {
        string login = null;
        int number = 1;

        Console.WriteLine("Список врачей Вашего отделения:\n");

        foreach (Doctor d in doctorsList)
        {
            login = d.CheckLogin();
            Console.WriteLine($"{number}. {login}  |  {d.FullName}  |  {d.Department}  |  {d.Specialization}\n");
            number++;
        }

        Console.WriteLine("\nНажмите Enter, чтобы выйти.");
        Console.ReadLine();
    }
    else
    {
        AddDoctor(admin, doctorsList);
    }
}

void CreateSchedule(Doctor doctor, List<Doctor> doctorsList, Admin admin)
{
    Console.Clear();
    bool trigger = true;

    if (doctorsList.Count > 0)
    {
        while (trigger)
        {
            Console.WriteLine("Введите день недели:");
            string day = Console.ReadLine();

            List <string> newSchedule = CreateScheduleDay(doctor, day);
 
            Console.WriteLine($"Расписание составлено на {day.ToLower()}. Что бы Вы хотели сделать?\n" + "1. Продублировать расписание на все дни недели.\n" + "2. Составить новое расписание для другого дня.\n" + "3. Открыть расписание.\n" + "4. Выйти.\n");
            int action = Convert.ToInt32(Console.ReadLine());

            switch (action)
            {
                case 1:
                    doctor.scheduleMon = newSchedule;
                    doctor.scheduleTue = newSchedule;
                    doctor.scheduleWed = newSchedule;
                    doctor.scheduleThu = newSchedule;
                    doctor.scheduleFri = newSchedule;

                    Console.WriteLine($"Расписание на неделю составлено. Что бы Вы хотели сделать?\n" + "1. Открыть расписание.\n" + "2. Выйти.\n");

                    int action1 = Convert.ToInt32(Console.ReadLine());

                    switch (action1)
                    {
                        case 1:

                            break;

                        case 2:
                            Console.Clear();
                            trigger = false;
                            break;
                    }

                    break;

                case 2:


                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine($"Врач: {doctor.FullName.ToUpper()}\n");

                    Console.WriteLine($"ДАТА: {doctor.scheduleMon[0]}");

                    for (int i = 1; i < doctor.scheduleMon.Count; i++)
                    {
                        Console.WriteLine($"{i}. {doctor.scheduleMon[i]}");
                    }

                    Console.WriteLine("\nНажмите Enter, чтобы выйти.");
                    Console.ReadLine();

                    Console.Clear();

                    break;

                case 4:
                    Console.Clear();
                    trigger = false;
                    break;
            }
        }
    }

    else
    {
        AddDoctor(admin, doctorsList);
    }
}

List<string> CreateScheduleDay(Doctor doctor, string day)
{
    Console.WriteLine($"ДОБАВЛЕНИЕ РАСПИСАНИЯ НА {day.ToUpper()}\n");

    Console.WriteLine($"Врач: {doctor.FullName.ToUpper()}\n");

    Console.WriteLine("Введите дату и часы приема через запятую. Пример: 01.01.2023, 8:00, 8:30, 9:00");
    Console.Write("Часы приема: ");
    string schedule = Console.ReadLine();

    Console.WriteLine();
    List<string> newSchedule = schedule.Split(',').ToList();

    bool trigger = true;

    while (trigger)
    {
        if (day.ToLower() == "понедельник")
        {
            doctor.AddMon(newSchedule);
            trigger = false;
        }
        else if (day.ToLower() == "вторник")
        {
            doctor.AddTue(newSchedule);
            trigger = false;
        }
        else if (day.ToLower() == "среда")
        {
            doctor.AddWed(newSchedule);
            trigger = false;
        }
        else if (day.ToLower() == "четверг")
        {
            doctor.AddThu(newSchedule);
            trigger = false;
        }
        else if (day.ToLower() == "пятница")
        {
            doctor.AddFri(newSchedule);
            trigger = false;
        }
        else
        {
            Console.WriteLine("Ошибка! Такого дня недели не существует. Попробуйте еще раз.");
        }
    }

    return newSchedule;
}

Doctor CreateDoctor__AdultDepartment()
{
    Console.WriteLine("ДОБАВЛЕНИЕ НОВОГО ВРАЧА\n");

    Console.Write("Логин:\t");
    string login = Console.ReadLine();

    Console.Write("Пароль:\t");
    string password = Console.ReadLine();

    string department = "Взрослое отделение";

    Console.Write("Специализация:\t");
    string specialization = Console.ReadLine();

    Console.Write("ФИО:\t");
    string fullName = Console.ReadLine();

    return new Doctor(login, password, department, specialization, fullName);
}

Doctor CreateDoctor__ChildrenDepartment()
{
    Console.WriteLine("ДОБАВЛЕНИЕ НОВОГО ВРАЧА\n");

    Console.Write("Логин:\t");
    string login = Console.ReadLine();

    Console.Write("Пароль:\t");
    string password = Console.ReadLine();

    string department = "Детское отделение";

    Console.Write("Специализация:\t");
    string specialization = Console.ReadLine();

    Console.Write("ФИО:\t");
    string fullName = Console.ReadLine();

    return new Doctor(login, password, department, specialization, fullName);
}


void AddDoctor(Admin admin, List<Doctor> doctorsList)
{
    Console.Clear();

    Console.WriteLine("Список врачей пуст. Желаете добавить нового врача?\n" + "1. Да.\n" + "2. Нет.\n");
    int actionAddDoctor = Convert.ToInt32(Console.ReadLine());

    switch (actionAddDoctor)
    {
        case 1:
            Console.Clear();

            if (admin.Department == "Взрослое отделение")
            {
                Doctor doctor = CreateDoctor__AdultDepartment();
                doctorsList.Add(doctor);
            }
            else if (admin.Department == "Детское отделение")
            {
                Doctor doctor = CreateDoctor__ChildrenDepartment();
                doctorsList.Add(doctor);
            }

            break;

        case 2:
            Console.Clear();
            break;
    }
}

//ДЕЙСТВИЯ В АККАУНТЕ АДМИНИСТРАТОРА



//ДЕЙСТВИЯ В АККАУНТЕ ВРАЧА

bool DoctorAccount(Doctor doctor, bool trigger)
{
    while (trigger != false)
    {
        Console.Clear();

        Console.WriteLine(doctor.FullName.ToUpper() + "\n");
        Console.WriteLine("Что бы Вы хотели сделать?\n" + "1. Начать прием пациентов.\n" + "2. Выйти из аккаунта.\n");

        Console.Write("Выберите действие: ");
        int actionAdmin = Convert.ToInt32(Console.ReadLine());

        switch (actionAdmin)
        {
            case 1:
                Console.Clear();

                Console.WriteLine("Укажите сегодняшнюю дату: ");
                string date = Console.ReadLine();

                Console.Clear();

                Console.WriteLine($"{doctor.FullName.ToUpper()}\n\n" + "ПРИЕМ ПАЦИЕНТОВ\n" + $"ДАТА: {date.ToUpper()}\n");


                break;

            case 2:
                trigger = false;
                Console.Clear();
                break;

        }
    }

    return false;
}


//ДЕЙСТВИЯ В АККАУНТЕ ВРАЧА



//ДЕЙСТВИЯ ПАЦИЕНТА

void MakeAppointment(List<Doctor> doctorsList__AD, List<Doctor> doctorsList__CD, bool trigger)
{
    while (trigger)
    {
        Console.Clear();

        Console.WriteLine("ЗАПИСЬ НА ПРИЕМ\n");

        Console.WriteLine("Что бы Вы хотели сделать?\n" + "1. Записать себя.\n" + "2. Записать ребенка.\n" + "2. Выйти.");
        int action = Convert.ToInt32(Console.ReadLine());

        switch (action)
        {
            case 1:
                Console.Clear();
                string login = null;
                int number = 1;

                Console.WriteLine("Выберите врача:");

                foreach (Doctor d in doctorsList__AD)
                {
                    login = d.CheckLogin();
                    Console.WriteLine($"{number}. |  {d.FullName}  |  {d.Specialization}\n");
                    number++;
                }

                Console.Write("Введите номер врача из списка: ");
                int doctorNumber = Convert.ToInt32(Console.ReadLine());

                Doctor specificDoctor = doctorsList__AD[doctorNumber];

                Console.Clear();


                break;
            case 2:
                Console.Clear();

                break;
            case 3:
                Console.Clear();
                trigger = false;
                break;

        }
    }
}








//ДЕЙСТВИЯ ПАЦИЕНТА