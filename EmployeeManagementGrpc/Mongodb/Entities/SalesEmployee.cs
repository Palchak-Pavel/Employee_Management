using EmployeeManagementGrpc.Common;
using EmployeeManagementGrpc.Mongodb.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EmployeeManagementGrpc.Mongodb.Entities;

public class SalesEmployee : EntityBase
{
    [BsonRepresentation(BsonType.ObjectId)]
    
    public string Id { get; set; } = null!;
    public List<Replacement> Replacements { get; set; } = null!;
}
