using WebApi.Models;
using System.Linq.Expressions;

namespace WebApi.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool Add(TEntity contact);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        TEntity? GetById(int id);
        bool Update(TEntity contact);
        bool Delete(int id);
    }
}
