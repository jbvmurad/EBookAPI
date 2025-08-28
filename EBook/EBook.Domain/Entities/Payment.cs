using EBook.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EBook.Domain.Entities;

public class Payment
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("paymentId")]
    public int PaymentId { get; set; }

    [BsonElement("status")]
    [BsonRepresentation(BsonType.String)]
    public PaymentStatus Status { get; set; } 

    [BsonElement("method")]
    [BsonRepresentation(BsonType.String)]
    public PaymentMethod Method { get; set; } 

    [BsonElement("order")]
    public List<Order> Orders { get; set; } = new List<Order>();
}
