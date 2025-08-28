using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EBook.Domain.Entities;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }= ObjectId.GenerateNewId().ToString();

    [BsonElement("userId")]
    public int UserId { get; set; }

    [BsonElement("username")]
    public string UserName { get; set; } = string.Empty;

    [BsonElement("email")]
    public string Email { get; set; } = string.Empty;

    [BsonElement("payment")]
    public List<Payment> Payments { get; set; } = new List<Payment>();
}
