using EBook.Application.Interfaces;
using EBook.Domain.Entities;
using EBook.Persistance.Context;
using MongoDB.Driver;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EBook.Infrastructure.Services;

public class MongoGenericService<T> : IGenericService<T> where T : class
{
    private readonly EBookContext _context;
    private readonly IMongoCollection<T> _collection;

    public MongoGenericService(EBookContext context)
    {
        _context = context;
        _collection = GetCollection();
    }

    private IMongoCollection<T> GetCollection()
    {
        return typeof(T).Name switch
        {
            nameof(User) => (IMongoCollection<T>)_context.Users,
            nameof(Book) => (IMongoCollection<T>)_context.Books,
            nameof(Category) => (IMongoCollection<T>)_context.Categories,
            nameof(Order) => (IMongoCollection<T>)_context.Orders,
            nameof(Payment) => (IMongoCollection<T>)_context.Payments,
            _ => throw new InvalidOperationException($"No collection configured for type {typeof(T).Name}")
        };
    }

    public void Add(T entity)
    {
        _collection.InsertOne(entity);
    }

    public int Count()
    {
        return (int)_collection.CountDocuments(FilterDefinition<T>.Empty);
    }

    public void Delete(int id)
    {
        FilterDefinition<T> filter = typeof(T).Name switch
        {
            nameof(User) => Builders<T>.Filter.Eq("userId", id),
            nameof(Book) => Builders<T>.Filter.Eq("bookId", id),
            nameof(Category) => Builders<T>.Filter.Eq("categoryId", id),
            nameof(Order) => Builders<T>.Filter.Eq("orderId", id),
            nameof(Payment) => Builders<T>.Filter.Eq("paymentId", id),
            _ => throw new InvalidOperationException($"No ID field configured for type {typeof(T).Name}")
        };

        var result = _collection.DeleteOne(filter);
        if (result.DeletedCount == 0)
        {
            throw new KeyNotFoundException($"Entity with ID {id} not found");
        }
    }

    public int FilteredCount(Expression<Func<T, bool>> predicate)
    {
        return (int)_collection.CountDocuments(predicate);
    }

    public T GetByFitered(Expression<Func<T, bool>> predicate)
    {
        return _collection.Find(predicate).FirstOrDefault();
    }

    public T GetById(int id)
    {
        FilterDefinition<T> filter = typeof(T).Name switch
        {
            nameof(User) => Builders<T>.Filter.Eq("userId", id),
            nameof(Book) => Builders<T>.Filter.Eq("bookId", id),
            nameof(Category) => Builders<T>.Filter.Eq("categoryId", id),
            nameof(Order) => Builders<T>.Filter.Eq("orderId", id),
            nameof(Payment) => Builders<T>.Filter.Eq("paymentId", id),
            _ => throw new InvalidOperationException($"No ID field configured for type {typeof(T).Name}")
        };

        var result = _collection.Find(filter).FirstOrDefault();
        if (result == null)
        {
            throw new KeyNotFoundException($"Entity with ID {id} not found");
        }
        return result;
    }

    public List<T> GetFilteredList(Expression<Func<T, bool>> predicate)
    {
        return _collection.Find(predicate).ToList();
    }

    public List<T> GetList()
    {
        return _collection.Find(FilterDefinition<T>.Empty).ToList();
    }

    public void Update(T entity)
    {
        int id = typeof(T).Name switch
        {
            nameof(User) => ((User)(object)entity).UserId,
            nameof(Book) => ((Book)(object)entity).BookId,
            nameof(Category) => ((Category)(object)entity).CategoryId,
            nameof(Order) => ((Order)(object)entity).OrderId,
            nameof(Payment) => ((Payment)(object)entity).PaymentId,
            _ => throw new InvalidOperationException($"No ID field configured for type {typeof(T).Name}")
        };

        FilterDefinition<T> filter = typeof(T).Name switch
        {
            nameof(User) => Builders<T>.Filter.Eq("userId", id),
            nameof(Book) => Builders<T>.Filter.Eq("bookId", id),
            nameof(Category) => Builders<T>.Filter.Eq("categoryId", id),
            nameof(Order) => Builders<T>.Filter.Eq("orderId", id),
            nameof(Payment) => Builders<T>.Filter.Eq("paymentId", id),
            _ => throw new InvalidOperationException($"No ID field configured for type {typeof(T).Name}")
        };

        var result = _collection.ReplaceOne(filter, entity);
        if (result.MatchedCount == 0)
        {
            throw new KeyNotFoundException($"Entity with ID {id} not found");
        }
    }
}