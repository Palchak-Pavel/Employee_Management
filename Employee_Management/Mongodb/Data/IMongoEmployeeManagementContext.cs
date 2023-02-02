using Employee_Management.Mongodb.Entities;
using MongoDB.Driver;

namespace Employee_Management.Mongodb.Data;

public interface IMongoEmployeeManagementContext
{
    IMongoCollection<Driver> Drivers { get; }
    IMongoCollection<WarehouseEmployee>WarehouseEmployees { get; }
    IMongoCollection<SalesEmployee> SalesEmployees { get; }
    IMongoCollection<Employee>Employees { get; }
}