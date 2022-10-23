namespace CompanyWorkers
{
    class AttributeSetting
    {
        static string errorMessage = "\nВы ввели неверное значение. Попробуйте еще раз: ";

        public static string StringValue(string message)
        {
            Console.Write(message);

            string? value = Console.ReadLine();
            return (!String.IsNullOrEmpty(value)) ? value.Trim() : StringValue(errorMessage);
        }
        public static int Numeric(string message)
        {
            Console.Write(message);

            bool convertationProcess = int.TryParse(Console.ReadLine(), out int value);
            return (convertationProcess) ? value : AttributeSetting.Numeric(errorMessage);
        }
    }

    class Worker
    {
        public string FirstName { get; set; } = "Unknown";
        public string LastName { get; set; } = "Unknown";
        public string Position { get; set; } = "Unknown";

        public int EmploymentTime { get; set; } = 0001;
        public int Salary { get; set; } = 0;

        public string Name
        {
            get => $"{FirstName} {LastName}";
        }

        public int WorkExperience
        {
            get => DateTime.Now.Year - EmploymentTime;
        }

        public Worker() { }

        public Worker(string firstName, string lastName, string position, int employmentTime, int salary)
        {
            FirstName = firstName;
            LastName = firstName;
            Position = position;
            EmploymentTime = employmentTime;
            Salary = salary;
        }

        public static bool operator > (Worker worker1, Worker worker2)
        {
            int result = string.Compare(worker1.LastName, worker2.LastName);
            return result < 0;
        }

        public static bool operator < (Worker worker1, Worker worker2)
        {
            int result = string.Compare(worker1.LastName, worker2.LastName);
            return result > 0;
        }
        public override string ToString() => $"\nФ.И.: {Name}\nГод трудоустройства: {EmploymentTime} г.\nСтаж работы: {WorkExperience}\nДолжность: {Position}\nЗарплата: {Salary:C0}\n";
    }

    class Company
    {
        private Worker[] workers;

        public int WorkerNumber { get => workers.Length; }
        public string Name { get; set; } = "Unknown";

        public Company(string name, int volume) { Name = name; workers = new Worker[volume]; }

        public Worker this[int index]
        {
            get => (index >= workers.Length || index < 0) ? throw new IndexOutOfRangeException() : workers[index];
            set => workers[index] = value;
        }

        public void AddingWorkers()
        {
            for (int i = 0; i < WorkerNumber; i++)
            {
                workers[i] = new Worker();

                Console.WriteLine();

                workers[i].FirstName = AttributeSetting.StringValue($"Введите {i + 1}-го имя сотрудника: ");
                workers[i].LastName = AttributeSetting.StringValue($"Введите {i + 1}-го фамилию сотрудника: ");
                workers[i].Position = AttributeSetting.StringValue($"Введите {i + 1}-го должность сотрудника: ");

                workers[i].EmploymentTime = AttributeSetting.Numeric($"Введите {i + 1}-го год трудоустройства сотрудника: ");
                workers[i].Salary = AttributeSetting.Numeric($"Введите {i + 1}-го зарплату сотрудника: ");

                Console.WriteLine( new string('_', 50) );
            }
        }

        public void FilteringWorkersByExperience(int desiredWorkExperience)
        {
            List<Worker>? workersExperienceYear = new List<Worker>();

            for (int i = 0; i < WorkerNumber; i++)
                if (workers[i].WorkExperience > desiredWorkExperience)
                    workersExperienceYear.Add( workers[i] );

            Console.WriteLine();

            if (workersExperienceYear.Count > 0)
                foreach (Worker worker in workersExperienceYear)
                    Console.WriteLine($"{worker.Name}\nСтаж работы: {worker.WorkExperience}\n");
            else
                Console.WriteLine("Сотрудников с указанным стажем работы нет!");

            Console.WriteLine( new string('_', 50) );
        }

        public void SortingWorkers()
        {
            Worker[] workersArrayForSorting = workers;

            for (int i = 0; i < WorkerNumber - 1; i++)
                for (int j = i + 1; j < WorkerNumber; j++)
                    if ( workersArrayForSorting[i] < workersArrayForSorting[j] )
                        ( workersArrayForSorting[i], workersArrayForSorting[j] ) = ( workersArrayForSorting[j], workersArrayForSorting[i] );

            foreach (Worker worker in workersArrayForSorting)
                Console.WriteLine(worker);
        }

    }
}
