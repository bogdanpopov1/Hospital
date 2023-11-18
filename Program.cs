using Hospital.Staff;

//"adminAdultDepartment", "adultDepartment2023"
Admin admin__AdultDepartment = new Admin("1", "1", "Взрослое отделение", "Никотяй Игорь Андреевич");
Admin admin__ChildrenDepartment = new Admin("adminChildrenDepartment", "childrenDepartment2023", "Детское отделение", "Чумаков Данил Дмитриевич");

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

Console.WriteLine("Добро пожаловать в нашу больницу!\n");

while (trigger1)
{
    Console.WriteLine("Что бы вы хотели сделать?\n" + "1. Войти как админ.\n" + "2. Войти как врач.\n" + "3. Записаться на приём.\n" + "4. Выйти из приложения.");

    int actionStart = Convert.ToInt32(Console.ReadLine());

    trigger2 = true;

    switch (actionStart)
    {
        case 1:
            Console.Clear();

            while (trigger2)
            {

                if (SignInAdmin(admin__AdultDepartment, admin__ChildrenDepartment) == true)
                {
                    Console.Clear();
                    trigger2 = AdminAccount(admin__AdultDepartment, doctorsList__AdultDepartment, trigger2);
                }
                else if (SignInAdmin(admin__AdultDepartment, admin__ChildrenDepartment) == false)
                {
                    Console.Clear();
                    trigger2 = AdminAccount(admin__ChildrenDepartment, doctorsList__ChildrenDepartment, trigger2);
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



bool SignInAdmin(Admin adminAdult, Admin adminChildren)
{
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

    if (login == checkLogin__AdultDepartment)
    {
        return true;
    }
    else
    {
        return false;
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
        Console.WriteLine("Что бы вы хотели сделать?\n" + "1. Посмотреть список врачей.\n" + "2. Добавить врача.\n" + "3. Удалить врача.\n" + "4. Поменять пароль.\n" + "5. Выйти из аккаунта");
        int actionAdmin = Convert.ToInt32(Console.ReadLine());

        switch (actionAdmin)
        {
            case 1:
                Console.Clear();

                if (doctorsList.Count > 0)
                {
                    foreach (Doctor doctor in doctorsList)
                    {
                        Console.WriteLine($"{doctor.FullName}  |  {doctor.Department}  |  {doctor.Specialization}\n");
                    }

                }
                else
                {
                    Console.WriteLine("Список врачей пуст. Пора принимать на работу!");
                }

                Console.WriteLine("Нажмите 1, чтобы выйти.");
                string exit = Console.ReadLine();

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