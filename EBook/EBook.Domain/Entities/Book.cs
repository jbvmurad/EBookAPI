using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EBook.Domain.Entities;

public class Book
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("bookId")]
    public int BookId { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("author")]
    public string Author { get; set; } = string.Empty;

    [BsonElement("price")]
    public decimal Price { get; set; }

    [BsonElement("categoryId")]
    public int CategoryId { get; set; }

    [BsonElement("category")]
    public Category Category { get; set; } = new Category();

}
