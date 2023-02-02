using Employee_Management.Mongodb.Entities;
using MongoDB.Driver;

namespace Employee_Management.Mongodb.Data;

public class EmployeeManagementContext : IMongoEmployeeManagementContext
{
    public EmployeeManagementContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        Drivers = database.GetCollection<Driver>("Drivers");
        WarehouseEmployees = database.GetCollection<WarehouseEmployee>("WarehouseEmployee");
        SalesEmployees = database.GetCollection<SalesEmployee>("SalesEmployee");
        Employees = database.GetCollection<Employee>("Employee");
    }

    public IMongoCollection<Driver> Drivers { get; }
    public IMongoCollection<WarehouseEmployee> WarehouseEmployees { get; }
    public IMongoCollection<SalesEmployee> SalesEmployees { get; }
    public IMongoCollection<Employee> Employees { get; }
}