using System.ComponentModel.DataAnnotations;
using Employee_Management.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Employee_Management.Mongodb.Entities;

public class Employee : EntityBase
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
    public string Work { get; set; } = null!;
}