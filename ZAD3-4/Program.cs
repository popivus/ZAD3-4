using ZAD3_4;

List<Employee> employees = InitEmployees().ToList();

Console.Clear();
while (true)
{
    Console.WriteLine($"Общее количество сотрудников: {Employee.CurrentEmployeCount}");

    Employee currentEmployee = PickEmployee(employees, "Введите номер сотрудника, над которым необходимо произвести операцию: ");

    Console.Clear();
    Console.WriteLine("1 - Получить рабочую информацию");
    Console.WriteLine("2 - Поменять должность");
    Console.WriteLine("3 - Начислить з/п");
    Console.WriteLine("4 - Получить личные данные");
    Console.WriteLine("5 - Сравнить с другим сотрудников");
    int operNumb = GetIntFromKeyboard("Введите номер операции: ", 1, 5);

    Console.Clear();
    switch(operNumb)
    {
        case 1:
            Console.WriteLine(currentEmployee.EmployeeInfo);
            Console.ReadKey();
            break;
        case 2:
            string newPosition = GetStringFromKeyboard("Введите новую должность: ");
            currentEmployee.EditPosition(newPosition);
            break;
        case 3:
            double salary = GetDoubleFromKeyboard("Введите деньги: ");
            currentEmployee.PaySalary(salary);
            break;
        case 4:
            Console.WriteLine(currentEmployee.PersonalData);
            Console.ReadKey();
            break;
        case 5:
            Employee employeeToCompare = PickEmployee(employees, "Введите номер сотрудника, с которым необходимо сравнить: ");
            Console.WriteLine();

            if (currentEmployee == employeeToCompare)
                Console.WriteLine("Это одинаковые сотрудники!");
            else
                Console.WriteLine("Это разные сотрудники!");
            Console.ReadKey();

            break;
    }
    Console.Clear();
}


Employee PickEmployee(List<Employee> employees, string message)
{
    for (int i = 0; i < employees.Count; i++)
        Console.WriteLine($"{i + 1} - {employees[i].Name}");

    int employeeNumber = GetIntFromKeyboard(message, 1, Employee.CurrentEmployeCount) - 1;

    return employees[employeeNumber];
}

IEnumerable<Employee> InitEmployees()
{
    int employeesCount = GetIntFromKeyboard("Введите корректное количество работников: ", 1, int.MaxValue);

    List<Employee> employees = new();
    for (int i = 0; i < employeesCount; i++)
    {
        string name = GetStringFromKeyboard("Введите имя нового сотрудника: ");
        char gender = GetIntFromKeyboard("Введите порядковый номер пола сотрудника (1 - М, 2 - Ж): ", 1, 2) == 1 ? 'М' : 'Ж';
        int age = GetIntFromKeyboard("Введите возраст: ", 1, 150);
        string position = GetStringFromKeyboard("Введите должность сотрудника: ");
        string organization = GetStringFromKeyboard("Введите организацию сотрудника: ");
        double experience = GetDoubleFromKeyboard("Введите стаж сотрудника: ");
        double salary = GetDoubleFromKeyboard("Введите накопления сотрудника: ");
        Console.WriteLine();

        Employee employee = new Employee(name, gender, age, position, organization, experience, salary);
        employees.Add(employee);
    }

    return employees;
}


string GetStringFromKeyboard(string message)
{
    Console.Write(message);
    return Console.ReadLine();
}

double GetDoubleFromKeyboard(string message)
{
    string? str;
    double number;
    do
    {
        Console.Write(message);
        str = Console.ReadLine();
    }
    while (!double.TryParse(str, out number) || number <= 0);

    return number;
}

int GetIntFromKeyboard(string message, int min, int max)
{
    string? str;
    int number;
    do
    {
        Console.Write(message);
        str = Console.ReadLine();
    }
    while (!int.TryParse(str, out number) || number < min || number > max);

    return number;
}