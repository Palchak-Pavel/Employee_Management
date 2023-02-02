using System.ComponentModel.DataAnnotations;
using Employee_Management.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Employee_Management.Mongodb.Entities;
public class WarehouseEmployee : EntityBase
{
    [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;
        
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{dd.MM.yyyy}", ApplyFormatInEditMode = true)]
    public DateTime CreatedAt { get; set; }
    
    public string Fio { get; set; } = null!;
    
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{dd.MM.yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? FiredAt { get; set; }
    
    public decimal Salary { get; set; } 
    public string Work { get; set; } = null!;
    public string[]? Bonus { get; set; } 
}