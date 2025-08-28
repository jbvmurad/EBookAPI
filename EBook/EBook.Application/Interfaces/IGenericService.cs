using System.Linq.Expressions;

namespace EBook.Application.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        List<T> GetList();
        T GetById(int id);
        T GetByFitered(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        int Count();
        int FilteredCount(Expression<Func<T, bool>> predicate);
        List<T> GetFilteredList(Expression<Func<T, bool>> predicate);
    }
}
