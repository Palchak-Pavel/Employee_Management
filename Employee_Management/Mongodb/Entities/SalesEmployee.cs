using System.ComponentModel.DataAnnotations;
using Employee_Management.Common;
using Employee_Management.Mongodb.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Employee_Management.Mongodb.Entities;

public class SalesEmployee : EntityBase
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{dd.MM.yyyy}", ApplyFormatInEditMode = true)]
    public DateTime CreatedAt { get; set; }
    
    public string Email { get; set; } = null!;
    public string Fio { get; set; } = null!;
    
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{dd.MM.yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? FiredAt { get; set; }
    public string Phone { get; set; } = null!;
    public string ShortName { get; set; } = null!;
    public List<Replacement> Replacements { get; set; } = null!;
    
}