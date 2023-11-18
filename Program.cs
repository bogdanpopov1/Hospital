using Hospital.Staff;
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
    Console.WriteLine("Что бы вы хотели сделать?\n" + "1. Войти как админ.\n" + "2. Войти как врач.\n" + "3. Записаться на приём.\n" + "4. Выйти из приложения.\n");

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
                } else
                {
                    Console.Clear();
                }

            }

            break;

        case 2:
            Console.WriteLine();

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
    } else if (login == checkLogin__ChildrenDepartment && password == checkPassword__ChildrenDepartment)
    {
        return "children";
    } else
    {
        Console.WriteLine("\nНеверно введен логин или пароль. Для того чтобы попробовать войти еще раз, нажмите Enter.");
        Console.ReadLine();
        return "error";
    }
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

bool AdminAccount(Admin admin, List<Doctor> doctorsList, bool trigger2)
{
    while (trigger2 != false)
    {
        Console.Clear();

        Console.WriteLine(admin.FullName.ToUpper() + "\n");
        Console.WriteLine("Что бы вы хотели сделать?\n" + "1. Посмотреть список врачей.\n" + "2. Добавить врача.\n" + "3. Удалить врача.\n" + "4. Поменять пароль.\n" + "5. Выйти из аккаунта.\n");

        Console.Write("Выберите действие: ");
        int actionAdmin = Convert.ToInt32(Console.ReadLine());

        switch (actionAdmin)
        {
            case 1:
                Console.Clear();

                ViewDoctorsList(doctorsList);

                break;


            case 2:
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

            case 3:
                Console.Clear();

                break;

            case 4:
                Console.Clear();

                break;

            case 5:
                trigger2 = false;
                Console.Clear();
                break;

        }
    }

    return false;
}


void ViewDoctorsList(List<Doctor> doctorsList)
{
    if (doctorsList.Count > 0)
    {
        string login = null;
        int number = 1;

        foreach (Doctor d in doctorsList)
        {
            login = d.CheckLogin();
            Console.WriteLine($"{number}. {login}  |  {d.FullName}  |  {d.Department}  |  {d.Specialization}\n");
            number++;
        }

        Console.WriteLine("Что бы вы хотели сделать?\n" + "1. Составить расписание приема врача.\n" + "2. Выйти.\n");
        int actionAdmin__DoctorList = Convert.ToInt32(Console.ReadLine());

        switch (actionAdmin__DoctorList)
        {
            case 1:
                Console.Clear();

                number = 1;

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

                CreateSchedule(specificDoctor);

                break;
        }

    }
    else
    {
        Console.WriteLine("Список врачей пуст. Пора принимать на работу!");
    }

}


void CreateSchedule(Doctor doctor)
{
    Console.Clear();

    Console.WriteLine("ДОБАВЛЕНИЕ РАСПИСАНИЯ\n");

    Console.WriteLine($"Врач: {doctor.FullName.ToUpper()}\n");

    Console.WriteLine("Введите часы приема через запятую. Пример: 08:00, 08:30, 09:00");
    Console.Write("Часы приема: ");
    string schedule = Console.ReadLine();

    Console.WriteLine();
    List<string> newSchedule = schedule.Split(',').ToList();
    doctor.AddList(newSchedule);

    Console.Clear();
    Console.WriteLine("Расписание составлено!\n");

    bool trigger3 = true;

    while (trigger3)
    {
        Console.WriteLine("Что бы Вы хотели сделать?\n" + "1. Открыть расписание.\n" + "2. Выйти.\n");
        int actionAdmin__DoctorList = Convert.ToInt32(Console.ReadLine());

        switch (actionAdmin__DoctorList)
        {
            case 1:
                Console.Clear();
                Console.WriteLine($"Врач: {doctor.FullName.ToUpper()}\n");

                int number = 1;

                foreach (string s in newSchedule)
                {
                    Console.WriteLine($"{number}. {s}");
                    number++;
                }

                Console.WriteLine("\nНажмите Enter, чтобы выйти.");
                Console.ReadLine();

                Console.Clear();

                break;

            case 2:
                Console.Clear();
                trigger3 = false;
                break;
        }
    
    }

}