using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EBook.Domain.Entities;

public class Category
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("categoryId")]
    public int CategoryId { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("books")]
    public List<Book> Books { get; set; } = new List<Book>();
}
