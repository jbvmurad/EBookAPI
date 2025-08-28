using EBook.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EBook.Domain.Entities;

public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("orderId")]
    public int OrderId { get; set; }

    [BsonElement("status")]
    [BsonRepresentation(BsonType.String)]
    public OrderStatus Status { get; set; }

    [BsonElement("orderDate")]
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [BsonElement("bookId")]
    public int BookId { get; set; }

    [BsonElement("book")]
    public Book Book { get; set; } = new Book();

    [BsonElement("userId")]
    public int UserId { get; set; }

    [BsonElement("user")]
    public User User { get; set; } = new User();
}
