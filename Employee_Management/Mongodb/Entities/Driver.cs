using System.ComponentModel.DataAnnotations;
using Employee_Management.Common;
using Employee_Management.Mongodb.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Employee_Management.Mongodb.Entities;

public class Driver : EntityBase
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
    
    public string Fio { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public Car Car { get; set; } = null!;
    
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{dd.MM.yyyy}", ApplyFormatInEditMode = true)]
    public DateTime CreatedAt { get; set; }
    
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{dd.MM.yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? FiredAt { get; set; }
    
    public bool Active { get; set; }
}