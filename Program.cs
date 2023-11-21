using Hospital.Staff;
using Hospital.Patients;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;


Admin admin__AdultDepartment = new Admin("adminAD", "passwordAD", "Взрослое отделение", "Никотяй Игорь Андреевич");
Admin admin__ChildrenDepartment = new Admin("adminCD", "passwordCD", "Детское отделение", "Чумаков Данил Дмитриевич");

List<Doctor> doctorsList__AdultDepartment = new List<Doctor>();
List<Doctor> doctorsList__ChildrenDepartment = new List<Doctor>();

bool trigger1 = true;
bool trigger2 = true;
string checkUser = null;

Console.WriteLine("Добро пожаловать в Клинику доктора Чумакова!\n");

while (trigger1)
{
    Console.Clear();

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

                checkUser = SignInAdmin(admin__AdultDepartment, admin__ChildrenDepartment);

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
            bool trigger = true;
            Console.Clear();

            if (doctorsList__AdultDepartment.Count > 0 || doctorsList__ChildrenDepartment.Count > 0)
            {
                while (trigger)
                {
                    trigger = MakeAppointment(doctorsList__AdultDepartment, doctorsList__ChildrenDepartment, trigger);
                }
            }
            else
            {
                Console.WriteLine("В базе данных больницы нет ни одного врача.");
                Console.WriteLine("\nНажмите Enter, чтобы выйти.");
                Console.ReadLine();
            }

            Console.Clear();
            break;

        case 4:
            Console.Clear();
            Console.WriteLine("Будьте здоровы!");
            trigger1 = false;
            break;
    }

}



string SignInAdmin(Admin adminAdult, Admin adminChildren)
{
    Console.Clear();

    Console.WriteLine("ВХОД ОТ ИМЕНИ АДМИНИСТРАТОРА\n");

    Console.Write("Введите логин:\t");
    string login = Console.ReadLine();
    string checkLogin__AdultDepartment = adminAdult.CheckLogin();
    string checkLogin__ChildrenDepartment = adminChildren.CheckLogin();

    while (login != checkLogin__AdultDepartment && login != checkLogin__ChildrenDepartment)
    {
        Console.WriteLine("Неверный логин! Попробуйте ещё раз:\t");
        login = Console.ReadLine();
    }

    Console.Write("\nВведите пароль:\t");
    string password = Console.ReadLine();
    string checkPassword__AdultDepartment = adminAdult.CheckPassword();
    string checkPassword__ChildrenDepartment = adminChildren.CheckPassword();

    while (password != checkPassword__AdultDepartment && password != checkPassword__ChildrenDepartment)
    {
        Console.WriteLine("\nНеверный пароль! Попробуйте ещё раз:\t");
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
        Console.Write("Введите логин:\t");
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

            }
            else
            {
                trigger1 = false;
            }
            trigger2 = false;
        }
    }

    bool trigger3 = true;

    while (trigger3)
    {
        Console.Write("\nВведите пароль:\t");
        password = Console.ReadLine();

        if (password != checkPassword)
        {
            Console.WriteLine("\nНеверный пароль! Попробуйте ещё раз:\t");
        }
        else
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
    }
    else
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
                        Console.WriteLine($"{number}. {login}  |  {d.FullName}  |  {d.Department}  |  {d.Specialization}\n");
                        number++;
                    }

                    Console.Write("\nВыберите врача для добавления расписания приема. Укажите его номер в списке: ");
                    int doctorNumber = Convert.ToInt32(Console.ReadLine()) - 1;

                    Doctor specificDoctor = doctorsList[doctorNumber];

                    Console.Clear();

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

        foreach (Doctor doctor in doctorsList)
        {
            login = doctor.CheckLogin();
            Console.WriteLine($"{number}. {login}  |  {doctor.FullName}  |  {doctor.Department}  |  {doctor.Specialization}\n");
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
    bool trigger = true;

    if (doctorsList.Count > 0)
    {
        Console.Clear();

        Console.WriteLine("СОСТАВЛЕНИЕ РАСПИСАНИЯ НА ПОНЕДЕЛЬНИК\n");

        Console.WriteLine("Введите дату понедельника следующей недели:");
        string date = Console.ReadLine();

        string day = "понедельник";

        List<string> newSchedule = CreateScheduleDay(doctor, day, date);

        Console.Clear();

        Console.WriteLine($"Расписание на понедельник составлено.");

        while (trigger)
        {
            Console.Clear();

            Console.WriteLine($"Что бы Вы хотели сделать?\n" + "1. Продублировать расписание на все дни недели.\n" + "2. Составить новое расписание для другого дня.\n" + "3. Открыть расписание.\n" + "4. Выйти.\n");
            int action = Convert.ToInt32(Console.ReadLine());

            switch (action)
            {
                case 1:
                    Console.Clear();

                    Console.Write("Введите дату вторника следующей недели: ");
                    string dateTue = Console.ReadLine();
                    doctor.AddTue(newSchedule);
                    doctor.scheduleTue.Insert(0, dateTue);
                    doctor.AddTue(newSchedule);

                    Console.Write("\nВведите дату среды следующей недели: ");
                    string dateWed = Console.ReadLine();
                    doctor.AddWed(newSchedule);
                    doctor.scheduleWed.Insert(0, dateWed);
                    doctor.AddWed(newSchedule);

                    Console.Write("\nВведите дату четверга следующей недели: ");
                    string dateThu = Console.ReadLine();
                    doctor.AddThu(newSchedule);
                    doctor.scheduleThu.Insert(0, dateThu);
                    doctor.AddThu(newSchedule);

                    Console.Write("\nВведите дату пятницы следующей недели: ");
                    string dateFri = Console.ReadLine();
                    doctor.AddFri(newSchedule);
                    doctor.scheduleFri.Insert(0, dateFri);
                    doctor.AddFri(newSchedule);

                    Console.Clear();

                    Console.WriteLine($"Расписание на неделю составлено. Что бы Вы хотели сделать?\n" + "1. Открыть расписание.\n" + "2. Выйти.\n");
                    Console.Write("Выберите действие: ");
                    int action1 = Convert.ToInt32(Console.ReadLine());

                    switch (action1)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine($"Врач: {doctor.FullName.ToUpper()}\n");

                            if (doctor.scheduleMon.Count > 0)
                            {
                                Console.WriteLine($"ДАТА: {doctor.scheduleMon[0]} (ПН)");

                                for (int i = 1; i < doctor.scheduleMon.Count; i++)
                                {
                                    Console.WriteLine($"{i}. {doctor.scheduleMon[i]}");
                                }

                                Console.WriteLine($"\nДАТА: {doctor.scheduleTue[0]} (ВТ)");

                                for (int i = 1; i < doctor.scheduleTue.Count; i++)
                                {
                                    Console.WriteLine($"{i}. {doctor.scheduleTue[i]}");
                                }

                                Console.WriteLine($"\nДАТА: {doctor.scheduleWed[0]} (СР)");

                                for (int i = 1; i < doctor.scheduleWed.Count; i++)
                                {
                                    Console.WriteLine($"{i}. {doctor.scheduleWed[i]}");
                                }

                                Console.WriteLine($"\nДАТА: {doctor.scheduleThu[0]} (ЧТ)");

                                for (int i = 1; i < doctor.scheduleThu.Count; i++)
                                {
                                    Console.WriteLine($"{i}. {doctor.scheduleThu[i]}");
                                }

                                Console.WriteLine($"\nДАТА: {doctor.scheduleFri[0]} (ПТ)");

                                for (int i = 1; i < doctor.scheduleFri.Count; i++)
                                {
                                    Console.WriteLine($"{i}. {doctor.scheduleFri[i]}");
                                }

                                Console.WriteLine("\nНажмите Enter, чтобы выйти.");
                                Console.ReadLine();
                            } else
                            {
                                Console.WriteLine("ДДДУРАК.");
                                Console.ReadLine();
                            }
                            

                            Console.Clear();
                            break;

                        case 2:
                            Console.Clear();
                            trigger = false;
                            break;
                    }

                    break;

                case 2:
                    Console.Clear();
                    bool trigger1 = true;

                    while (trigger1)
                    {
                        Console.WriteLine("Введите день недели:");
                        string newDay = Console.ReadLine();

                        if (newDay.ToLower() == "вторник")
                        {
                            day = "вторник";
                            Console.WriteLine("\nВведите дату вторника следующей недели:");
                            date = Console.ReadLine();
                            newSchedule = CreateScheduleDay(doctor, day, date);
                            trigger1 = false;
                        }
                        else if (newDay.ToLower() == "среда")
                        {
                            day = "среду";
                            Console.WriteLine("\nВведите дату среды следующей недели:");
                            date = Console.ReadLine();
                            newSchedule = CreateScheduleDay(doctor, day, date);
                            trigger1 = false;
                        }
                        else if (newDay.ToLower() == "четверг")
                        {
                            day = "четверг";
                            Console.WriteLine("\nВведите дату четверга следующей недели:");
                            date = Console.ReadLine();
                            newSchedule = CreateScheduleDay(doctor, day, date);
                            trigger1 = false;
                        }
                        else if (newDay.ToLower() == "пятница")
                        {
                            day = "пятницу";
                            Console.WriteLine("\nВведите дату пятницы следующей недели:");
                            date = Console.ReadLine();
                            newSchedule = CreateScheduleDay(doctor, day, date);
                            trigger1 = false;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка! Такого дня недели не существует. Попробуйте еще раз.\n");
                        }
                    }

                    break;

                case 3:
                    Console.Clear();

                    if (doctor.scheduleMon.Count > 0 || doctor.scheduleTue.Count > 0 || doctor.scheduleWed.Count > 0 || doctor.scheduleThu.Count > 0 || doctor.scheduleFri.Count > 0)
                    {
                        Console.WriteLine($"Врач: {doctor.FullName.ToUpper()}\n");

                        if (doctor.scheduleMon.Count > 0)
                        {
                            Console.WriteLine($"ДАТА: {doctor.scheduleMon[0]} (ПН)");

                            for (int i = 1; i < doctor.scheduleMon.Count; i++)
                            {
                                Console.WriteLine($"{i}. {doctor.scheduleMon[i]}");
                            }
                        }
                        
                        if (doctor.scheduleTue.Count > 0)
                        {
                            Console.WriteLine($"\nДАТА: {doctor.scheduleTue[0]} (ВТ)");

                            for (int i = 1; i < doctor.scheduleTue.Count; i++)
                            {
                                Console.WriteLine($"{i}. {doctor.scheduleTue[i]}");
                            }
                        }
                        
                        if (doctor.scheduleWed.Count > 0)
                        {
                            Console.WriteLine($"\nДАТА: {doctor.scheduleWed[0]} (СР)");

                            for (int i = 1; i < doctor.scheduleWed.Count; i++)
                            {
                                Console.WriteLine($"{i}. {doctor.scheduleWed[i]}");
                            }
                        }
                        
                        if (doctor.scheduleThu.Count > 0)
                        {
                            Console.WriteLine($"\nДАТА: {doctor.scheduleThu[0]} (ЧТ)");

                            for (int i = 1; i < doctor.scheduleThu.Count; i++)
                            {
                                Console.WriteLine($"{i}. {doctor.scheduleThu[i]}");
                            }
                        }
                        
                        if (doctor.scheduleFri.Count > 0)
                        {
                            Console.WriteLine($"\nДАТА: {doctor.scheduleFri[0]} (ПТ)");

                            for (int i = 1; i < doctor.scheduleFri.Count; i++)
                            {
                                Console.WriteLine($"{i}. {doctor.scheduleFri[i]}");
                            }
                        }
                        
                        Console.WriteLine("\nНажмите Enter, чтобы выйти.");
                        Console.ReadLine();

                        Console.Clear();

                    }
                    else
                    {
                        Console.WriteLine("Расписание еще не составлено.");
                        Console.WriteLine("\nНажмите Enter, чтобы выйти.");
                        Console.ReadLine();
                    }

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

List<string> CreateScheduleDay(Doctor doctor, string day, string date)
{
    Console.Clear();

    Console.WriteLine($"СОСТАВЛЕНИЕ РАСПИСАНИЯ НА {day.ToUpper()}\n");

    Console.WriteLine($"Врач: {doctor.FullName.ToUpper()}\n");

    Console.WriteLine("Введите часы приема через запятую. Пример: 8:00, 8:30, 9:00");
    Console.Write("Часы приема: ");
    string schedule = Console.ReadLine();

    Console.WriteLine();
    List<string> newSchedule = schedule.Split(',').ToList();

    newSchedule.Insert(0, date);

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
        else if (day.ToLower() == "среду")
        {
            doctor.AddWed(newSchedule);
            trigger = false;
        }
        else if (day.ToLower() == "четверг")
        {
            doctor.AddThu(newSchedule);
            trigger = false;
        }
        else if (day.ToLower() == "пятницу")
        {
            doctor.AddFri(newSchedule);
            trigger = false;
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
    Console.Write("Выберите действие: ");
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

                if (doctor.Department == "Взрослое отделение")
                {
                    foreach (var patient in doctor.patientsList__AD)
                    {
                        if (date == patient.ReceptionDay)
                        {
                            doctor.todayList.Add(patient);
                        }
                    }

                    doctor.todayList.Sort((p1, p2) => p1.ReceptionTime.CompareTo(p2.ReceptionTime));

                    // ОЧЕРЕДЬ ВОТ ОНА РОДИМАЯ !!!!!!!!!!!!!! 🐈meow

                    foreach (var patient in doctor.todayList)
                    {
                        doctor.todayQueue.Enqueue(patient);
                    }

                    bool trigger1 = true;

                    while (trigger1)
                    {
                        if (doctor.todayQueue.Count > 0)
                        {
                            Console.Clear();

                            Console.WriteLine("Принять пациента?\n" + "1. Да.\n" + "2.Нет.\n");
                            int action = Convert.ToInt32(Console.ReadLine());

                            switch (action)
                            {
                                case 1:
                                    Console.Clear();

                                    ReceptionOfPatients(doctor, date);

                                    Console.WriteLine("\nНажмите Enter, чтобы закончить прием.");
                                    Console.ReadLine();
                                    break;

                                case 2:
                                    Console.Clear();
                                    trigger1 = false;
                                    break;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Нет пациентов.");
                            Console.WriteLine("\nНажмите Enter, чтобы выйти.");
                            Console.ReadLine();
                            trigger1 = false;
                        }
                    }


                }
                else if (doctor.Department == "Детское отделение")
                {
                    foreach (var patient in doctor.patientsList__CD)
                    {
                        if (date == patient.ReceptionDay)
                        {
                            doctor.todayList__Minor.Add(patient);
                        }
                    }

                    doctor.todayList.Sort((p1, p2) => p1.ReceptionTime.CompareTo(p2.ReceptionTime));

                    foreach (var patient in doctor.todayList__Minor)
                    {
                        doctor.todayQueue__Minor.Enqueue(patient);
                    }

                    bool trigger2 = true;

                    while (trigger2)
                    {
                        if (doctor.todayQueue__Minor.Count > 0)
                        {
                            Console.Clear();

                            Console.WriteLine("Принять пациента?\n" + "1. Да.\n" + "2.Нет.\n");
                            int action = Convert.ToInt32(Console.ReadLine());

                            switch (action)
                            {
                                case 1:
                                    Console.Clear();

                                    ReceptionOfPatients(doctor, date);

                                    Console.WriteLine("\nНажмите Enter, чтобы закончить прием.");
                                    Console.ReadLine();
                                    break;

                                case 2:
                                    Console.Clear();
                                    trigger1 = false;
                                    break;
                            }
                        }

                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Нет пациентов.");
                            Console.WriteLine("\nНажмите Enter, чтобы выйти.");
                            Console.ReadLine();
                            trigger2 = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nДанные не найдены. Повторите попытку.");
                    Console.WriteLine("\nНажмите Enter, чтобы выйти.");
                    Console.ReadLine();
                    break;
                }

            break;

            case 2:
                trigger = false;
                Console.Clear();
                break;

        }
    }

    return false;
}

void ReceptionOfPatients(Doctor doctor, string date)
{
    Console.Clear();

    Console.WriteLine($"{doctor.FullName.ToUpper()}\n" + "ПРИЕМ ПАЦИЕНТОВ" + $"ДАТА: {date.ToUpper()}\n");

    Patient patient = doctor.todayQueue.Dequeue();

    Console.WriteLine($"ВРЕМЯ ПРИЕМА: {patient.ReceptionTime}\n");
    Console.WriteLine("ДАННЫЕ ПАЦИЕНТА:\n");
    Console.WriteLine($"ФИО: {patient.FullName}\n", $"ДАТА РОЖДЕНИЯ: {patient.BirthDate}\n" + $"ПОЛ: {patient.Gender}\n");
    Console.Write("ДИАГНОЗ: ");
    patient.Diagnose = Console.ReadLine();
}

void ReceptionOfPatients__Minor(Doctor doctor, string date)
{
    Console.Clear();

    Console.WriteLine($"{doctor.FullName.ToUpper()}\n" + "ПРИЕМ ПАЦИЕНТОВ" + $"ДАТА: {date.ToUpper()}\n");

    MinorPatient patient = doctor.todayQueue__Minor.Dequeue();

    Console.WriteLine($"ВРЕМЯ ПРИЕМА: {patient.ReceptionTime}\n");

    Console.WriteLine("ДАННЫЕ РОДИТЕЛЯ:");
    Console.WriteLine($"ФИО: {patient.ParentName}\n", $"НОМЕР ТЕЛЕФОНА: {patient.ParentPhoneNumber}\n");

    Console.WriteLine("ДАННЫЕ ПАЦИЕНТА:");
    Console.WriteLine($"ФИО: {patient.FullName}\n", $"ДАТА РОЖДЕНИЯ: {patient.BirthDate}\n" + $"ПОЛ: {patient.Gender}\n");
    Console.Write("ДИАГНОЗ: ");
    patient.Diagnose = Console.ReadLine();
}

//ДЕЙСТВИЯ В АККАУНТЕ ВРАЧА



//ДЕЙСТВИЯ ПАЦИЕНТА

bool MakeAppointment(List<Doctor> doctorsList__AD, List<Doctor> doctorsList__CD, bool trigger)
{
    while (trigger)
    {
        Console.Clear();

        Console.WriteLine("ЗАПИСЬ НА ПРИЕМ\n");

        Console.WriteLine("Что бы Вы хотели сделать?\n" + "1. Записать себя.\n" + "2. Записать ребенка.\n" + "2. Выйти.\n");
        Console.Write("Выберите действие: ");
        int action = Convert.ToInt32(Console.ReadLine());

        switch (action)
        {
            case 1:
                if (doctorsList__AD.Count > 0)
                {
                    Console.Clear();
                    string login = null;
                    int number = 1;

                    Console.WriteLine("Выберите врача:");

                    foreach (Doctor d in doctorsList__AD)
                    {
                        login = d.CheckLogin();
                        Console.WriteLine($"{number}.  {d.FullName}  |  {d.Specialization}\n");
                        number++;
                    }

                    Console.Write("Введите номер врача из списка: ");
                    int doctorNumber = Convert.ToInt32(Console.ReadLine());

                    Doctor doctor = doctorsList__AD[doctorNumber - 1];

                    bool trigger1 = true;

                    while (trigger1)
                    {
                        Console.Clear();

                        Console.WriteLine($"ВРАЧ: {doctor.FullName.ToUpper()} ({doctor.Specialization.ToUpper()})\n");

                        Console.Write($"Доступные даты для записи: {doctor.scheduleMon[0]}, {doctor.scheduleTue[0]}, {doctor.scheduleWed[0]}, {doctor.scheduleThu[0]}, {doctor.scheduleFri[0]}\n" + "Выберите дату: ");
                        string date = Console.ReadLine();

                        if (date == doctor.scheduleMon[0])
                        {
                            PrintData(doctor, date, doctor.scheduleMon);
                            trigger1 = false;
                        }
                        else if (date == doctor.scheduleTue[0])
                        {
                            PrintData(doctor, date, doctor.scheduleTue);
                            trigger1 = false;
                        }
                        else if (date == doctor.scheduleWed[0])
                        {
                            PrintData(doctor, date, doctor.scheduleWed);
                            trigger1 = false;
                        }
                        else if (date == doctor.scheduleThu[0])
                        {
                            PrintData(doctor, date, doctor.scheduleThu);
                            trigger1 = false;
                        }
                        else if (date == doctor.scheduleFri[0])
                        {
                            PrintData(doctor, date, doctor.scheduleFri);
                            trigger1 = false;
                        }
                        else
                        {
                            Console.WriteLine("\nВведена некорректная дата. Нажмите Enter, чтобы повторить попытку.");
                            Console.ReadLine();
                        }
                    }
                } else
                {
                    Console.WriteLine("В базе данных больницы нет ни одного врача.");
                    Console.WriteLine("\nНажмите Enter, чтобы выйти.");
                    Console.ReadLine();
                }

                break;

            case 2:
                if (doctorsList__CD.Count > 0)
                {
                    Console.Clear();
                    string login = null;
                    int number = 1;

                    Console.WriteLine("Выберите врача:");

                    foreach (Doctor d in doctorsList__CD)
                    {
                        login = d.CheckLogin();
                        Console.WriteLine($"{number}. |  {d.FullName}  |  {d.Specialization}\n");
                        number++;
                    }

                    Console.Write("Введите номер врача из списка: ");
                    int doctorNumber = Convert.ToInt32(Console.ReadLine());

                    Doctor doctor = doctorsList__CD[doctorNumber];

                    trigger1 = true;

                    while (trigger1)
                    {
                        Console.Clear();

                        Console.WriteLine($"ВРАЧ: {doctor.FullName.ToUpper()} ({doctor.Specialization.ToUpper()})\n");

                        Console.Write($"Доступные даты для записи: {doctor.scheduleMon[0]}, {doctor.scheduleTue[0]}, {doctor.scheduleWed[0]}, {doctor.scheduleThu[0]}, {doctor.scheduleFri[0]}\n" + "Выберите дату: ");
                        string date = Console.ReadLine();

                        if (date == doctor.scheduleMon[0])
                        {
                            PrintData(doctor, date, doctor.scheduleMon);
                            trigger1 = false;
                        }
                        else if (date == doctor.scheduleTue[0])
                        {
                            PrintData(doctor, date, doctor.scheduleTue);
                            trigger1 = false;
                        }
                        else if (date == doctor.scheduleWed[0])
                        {
                            PrintData(doctor, date, doctor.scheduleWed);
                            trigger1 = false;
                        }
                        else if (date == doctor.scheduleThu[0])
                        {
                            PrintData(doctor, date, doctor.scheduleThu);
                            trigger1 = false;
                        }
                        else if (date == doctor.scheduleFri[0])
                        {
                            PrintData(doctor, date, doctor.scheduleFri);
                            trigger1 = false;
                        }
                        else
                        {
                            Console.WriteLine("\nВведена некорректная дата. Нажмите Enter, чтобы повторить попытку.");
                            Console.ReadLine();
                        }
                    }
                } else
                {
                    Console.WriteLine("В базе данных больницы нет ни одного врача.");
                    Console.WriteLine("\nНажмите Enter, чтобы выйти.");
                    Console.ReadLine();
                }
                

                break;

            case 3:
                Console.Clear();
                trigger = false;
                break;

        }
    }

    return false;
}


void PrintData(Doctor doctor, string date, List<string> schedule)
{
    bool trigger = true;

    while (trigger)
    {
        Console.Clear();

        Console.WriteLine($"РАСПИСАНИЕ НА {date}");

        for (int i = 1; i < schedule.Count; i++)
        {
            Console.WriteLine($"{i}. {schedule[i]}");
        }

        Console.Write("Выберите время (укажите порядковый номер в списке): ");
        int time = Convert.ToInt32(Console.ReadLine());

        if (time <= schedule.Count && time > 0)
        {
            for (int i = 1; i < schedule.Count; i++)
            {
                if (time == i)
                {
                    Console.Clear();

                    Console.WriteLine($"ВРАЧ: {doctor.FullName.ToUpper()} ({doctor.Specialization.ToUpper()})");
                    Console.WriteLine($"ДАТА: {date} (ПН)");
                    Console.WriteLine($"ВРЕМЯ: {schedule[i]}\n");

                    Console.WriteLine($"Желаете записаться?\n" + "1. Да.\n" + "2. Нет.\n");
                    int actionUser = Convert.ToInt32(Console.ReadLine());

                    switch (actionUser)
                    {
                        case 1:
                            Console.Clear();

                            Console.WriteLine($"ВРАЧ: {doctor.FullName.ToUpper()} ({doctor.Specialization.ToUpper()})");
                            Console.WriteLine($"ДАТА: {date} (ПН)");
                            Console.WriteLine($"ВРЕМЯ: {schedule[i]}\n");

                            Console.Write("ЗАПОЛНЕНИЕ ДАННЫХ\n");

                            Console.Write("ФИО: ");
                            string fullName = Console.ReadLine();

                            Console.Write("Дата рождения: ");
                            string birthDate = Console.ReadLine();

                            Console.Write("Пол: ");
                            string gender = Console.ReadLine();

                            Console.Write("Полис ОМС: ");
                            string policy = Console.ReadLine();

                            Console.WriteLine("Вы успешно записаны!");

                            Patient patient = new Patient(fullName, birthDate, gender, policy, date, schedule[i]);

                            doctor.patientsList__AD.Add(patient);

                            schedule.RemoveAt(i);

                            Console.WriteLine("\nНажмите Enter, чтобы выйти.");
                            Console.ReadLine();
                            trigger = false;
                            break;

                        case 2:
                            Console.Clear();
                            trigger = false;
                            break;
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("\nВведен некорректный номер в списке. Нажмите Enter, чтобы повторить попытку.");
            Console.ReadLine();
        }
    }
}


void PrintData__MinorPatient(Doctor doctor, string date, List<string> schedule)
{
    bool trigger = true;

    while (trigger)
    {
        Console.Clear();

        Console.WriteLine($"РАСПИСАНИЕ НА {date}");

        for (int i = 1; i < schedule.Count; i++)
        {
            Console.WriteLine($"{i}. {schedule[i]}");
        }

        Console.Write("Выберите время (укажите порядковый номер в списке): ");
        int time = Convert.ToInt32(Console.ReadLine());

        if (time <= schedule.Count && time > 0)
        {
            for (int i = 1; i < schedule.Count; i++)
            {
                if (time == i)
                {
                    Console.Clear();

                    Console.WriteLine($"ВРАЧ: {doctor.FullName.ToUpper()} ({doctor.Specialization.ToUpper()})");
                    Console.WriteLine($"ДАТА: {date} (ПН)");
                    Console.WriteLine($"ВРЕМЯ: {schedule[i]}\n");

                    Console.WriteLine($"Желаете записаться?\n" + "1. Да.\n" + "2. Нет.\n");
                    int actionUser = Convert.ToInt32(Console.ReadLine());

                    switch (actionUser)
                    {
                        case 1:
                            Console.Clear();

                            Console.WriteLine($"ВРАЧ: {doctor.FullName.ToUpper()} ({doctor.Specialization.ToUpper()})");
                            Console.WriteLine($"ДАТА: {date} (ПН)");
                            Console.WriteLine($"ВРЕМЯ: {schedule[i]}\n");

                            Console.Write("ЗАПОЛНЕНИЕ ДАННЫХ РОДИТЕЛЯ\n");

                            Console.Write("ФИО: ");
                            string parentName = Console.ReadLine();

                            Console.Write("НОМЕР ТЕЛЕФОНА: ");
                            int parentPhoneNumber = Convert.ToInt32(Console.ReadLine());

                            Console.Write("\nЗАПОЛНЕНИЕ ДАННЫХ РЕБЕНКА\n");

                            Console.Write("ФИО РЕБЕНКА: ");
                            string fullName = Console.ReadLine();

                            Console.Write("Дата рождения: ");
                            string birthDate = Console.ReadLine();

                            Console.Write("Пол: ");
                            string gender = Console.ReadLine();

                            Console.Write("Полис ОМС: ");
                            string policy = Console.ReadLine();

                            Console.WriteLine("Вы успешно записаны!");

                            MinorPatient minorPatient = new MinorPatient(parentName, parentPhoneNumber, fullName, birthDate, gender, policy, date, schedule[i]);

                            doctor.patientsList__CD.Add(minorPatient);

                            schedule.RemoveAt(i);

                            Console.WriteLine("\nНажмите Enter, чтобы выйти.");
                            Console.ReadLine();
                            trigger = false;
                            break;

                        case 2:
                            Console.Clear();
                            trigger = false;
                            break;
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("\nВведен некорректный номер в списке. Нажмите Enter, чтобы повторить попытку.");
            Console.ReadLine();
        }
    }
}


//ДЕЙСТВИЯ ПАЦИЕНТА