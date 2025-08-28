using EBook.Application.DTOs.MongoDbDTO;
using EBook.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EBook.Persistance.Context
{
    public class EBookContext
    {
        private readonly IMongoDatabase _database;

        public EBookContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Book> Books => _database.GetCollection<Book>("Books");
        public IMongoCollection<Category> Categories => _database.GetCollection<Category>("Categories");
        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");
        public IMongoCollection<Payment> Payments => _database.GetCollection<Payment>("Payments");

    }
}
