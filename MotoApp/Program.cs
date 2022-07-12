using MotoApp.Data;
using MotoApp.Entities;
using MotoApp.Repositories;
using MotoApp.Repositories.Extensions;

var employeeRepository = new SqlRepository<Employee>(new MotoAppDbContext());
var businessPartnerRepository = new SqlRepository<BusinessPartner>(new MotoAppDbContext(), BusinessPartnerAdded);
employeeRepository.ItemAdded += EmployeeAdded;

AddEmployee(employeeRepository);
AddBusinessPartner(businessPartnerRepository);

WriteAllToConsole(employeeRepository);
WriteAllToConsole(businessPartnerRepository);

static void AddEmployee(IRepository<Employee> employeeRepository)
{
    var employess = new[]
    {
        new Employee { FirstName = "Damian" },
        new Employee { FirstName = "Magdalena"},
        new Manager { FirstName = "Adam"}
    };
    employeeRepository.AddBatch(employess);
}

static void AddBusinessPartner(IRepository<BusinessPartner> businessPartnerRepository)
{
    var businessPartners = new[]
    {
        new BusinessPartner { Name = "Krzysztof" },
        new BusinessPartner { Name = "Szymon" }

    };
    businessPartnerRepository.AddBatch(businessPartners);
}

static void EmployeeAdded(object? sender, Employee item) //eventhandler
{
    Console.WriteLine($"Employee added => {item.FirstName} from {sender?.GetType().Name} added");
}

static void BusinessPartnerAdded(BusinessPartner item) //delegat action
{
    Console.WriteLine($"Business Partner {item.Name} added");
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
