using MotoApp.Data;
using MotoApp.Entities;
using MotoApp.Repositories;

var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());
AddEmployee(employeeRepository);
AddManagers(employeeRepository);
WriteAllToConsole(employeeRepository);

static void AddEmployee(IWriteRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Damian" });
    employeeRepository.Add(new Employee { FirstName = "Krzysztof" });
    employeeRepository.Add(new Employee { FirstName = "Szymon" });
    employeeRepository.Save();
}

static void AddManagers (IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Adam" });
    managerRepository.Add(new Manager { FirstName = "Zuzia" });
    managerRepository.Save();
}
static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
