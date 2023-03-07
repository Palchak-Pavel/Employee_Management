using EmployeeManagementGrpc.Mongodb.Entities;
using MongoDB.Driver;

namespace EmployeeManagementGrpc.Mongodb.Data;

public interface IMongoEmployeeContext
{
    IMongoCollection<SalesEmployee> SalesEmployees { get; }
}