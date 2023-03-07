using EmployeeManagementGrpc.Mongodb.Entities;
using MongoDB.Driver;

namespace EmployeeManagementGrpc.Mongodb.Data;

  public class EmployeeManagementContext : IMongoEmployeeContext
{
        public EmployeeManagementContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        SalesEmployees = database.GetCollection<SalesEmployee>("SalesEmployee");

    }
    public IMongoCollection<SalesEmployee> SalesEmployees { get; }

}

