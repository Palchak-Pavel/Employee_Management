using EmployeeManagementGrpc.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace EmployeeManagementGrpc.Mongodb.ValueObjects;

public class ReplacementEmployee : ValueObject
{
    public ReplacementEmployee(string id, string email, string fio, string phone)
    {
        Id = id;
        Email = email;
        Fio = fio;
        Phone = phone;
    }
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; private set; }
    public string Email { get; private set; }
    public string Fio { get; private set; }
    public string Phone { get; private set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
        yield return Email;
        yield return Fio;
        yield return Phone;
    }
}