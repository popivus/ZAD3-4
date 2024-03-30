namespace ZAD3_4
{
    public class Employee
    {
        private static int _employeeCount;
        public static int CurrentEmployeCount => _employeeCount;

        public Employee(string name, char gender, int age, string position, string organization, double experience, double salary)
        {
            Name = name;
            Gender = gender;
            Age = age;
            Position = position;
            Organization = organization;
            Experience = experience;
            Salary = salary;

            _employeeCount++;
        }

        ~Employee() => _employeeCount--;

        private int _age;
        private double _experience;
        private double _salary;

        public string Name { get; private set; }

        public char Gender { get; private set; }

        public int Age 
        { 
            get => _age;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Возраст не может быть меньше или равен 0");

                _age = value;
            }
        }

        public string Position { get; private set; }

        public string Organization { get; private set; }

        public double Experience 
        { 
            get => _experience;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Стаж не может быть меньше 0");

                _experience = value;
            }
        }

        public double Salary 
        { 
            get => _salary;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Зарплата не может быть меньше или равна 0");

                _salary = value;
            }
        }

        public string EmployeeInfo => $"Работает в {Organization}\n" +
            $"На должности {Position}\n" +
            $"Стаж: {Experience}\n" +
            $"Зарплата: {Salary} руб.\n\n";

        public void EditPosition(string newPosition) => Position = newPosition;

        public void PaySalary(double money) => Salary += money;

        public string PersonalData => $"Имя работника {Name}\n" +
            $"Возраст {Age}\n" +
            $"Пол: {Gender}";

        public override bool Equals(object? obj)
        {
            if (obj is Employee emp)
            {
                if (Name == emp.Name &&
                    Gender == emp.Gender &&
                    Age == emp.Age &&
                    Position == emp.Position &&
                    Organization == emp.Organization &&
                    Experience == emp.Experience &&
                    Salary == emp.Salary)
                    return true;

                return false;
            }

            return false;
        }

        public static bool operator ==(Employee employee1, Employee employee2) => employee1.Equals(employee2);

        public static bool operator !=(Employee employee1, Employee employee2) => !employee1.Equals(employee2);

        public Employee Copy() => new Employee(Name, Gender, Age, Position, Organization, Experience, Salary);
    }
}
