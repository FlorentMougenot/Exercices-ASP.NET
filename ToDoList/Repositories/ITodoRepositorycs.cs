using ToDoList.Models;
using System.Linq.Expressions;

namespace ToDoList.Repositories
{
    public interface ITodoRepository
    {
        bool Add(Todo todo);
        Todo? Get(Expression<Func<Todo, bool>> predicate);
        List<Todo> GetAll();
        List<Todo> GetAll(Expression<Func<Todo, bool>> predicate);
        Todo? GetById(int id);
        bool Update(Todo todo);
        bool Delete(int id);
    }
}
