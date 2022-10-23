using CompanyWorkers;

Company company = new Company("Microsoft", 2);
company.AddingWorkers();

int userAction;
bool container = true;

do
{
    Console.WriteLine("\n1. Вывести отсортированный список сотрудников;\n2. Вывести сотрудников по выбранному стажу.\n3. Выход\n");
    userAction = AttributeSetting.Numeric("\nВыберите действие: ");

    switch(userAction)
    {
        case 1:
            company.SortingWorkers();
            break;
        case 2:
            int desiredWorkExperience = AttributeSetting.Numeric("\nВведите искомый стаж работы: ");
            company.FilteringWorkersByExperience(desiredWorkExperience);
            break;
        case 3:
            container = false;
            break;
        default:
            Console.WriteLine("\nВы не выбрали действие!");
            break;
    }
} while(container);
