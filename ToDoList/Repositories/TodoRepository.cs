using System.Linq.Expressions;
using ToDoList.Data;
using ToDoList.Models;


namespace ToDoList.Repositories
{
    public class TodoRepository : IRepository<Todo>
    {
        private ApplicationDbContext _dbContext;
        public TodoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool Add(Todo todo)
        {
            var addedObj = _dbContext.Todos.Add(todo);
            _dbContext.SaveChanges();
            return addedObj.Entity.Id > 0;
        }

        public Todo? GetById(int id)
        {
            return _dbContext.Todos.Find(id);
        }
        public Todo? Get(Expression<Func<Todo, bool>> predicate)
        {
            return _dbContext.Todos.FirstOrDefault(predicate);
        }
        public List<Todo> GetAll()
        {
            return _dbContext.Todos.ToList();
        }
        public List<Todo> GetAll(Expression<Func<Todo, bool>> predicate)
        {
            return _dbContext.Todos.Where(predicate).ToList();
        }

        // UPDATE
        public bool Update(Todo todo)
        {
            var todoFromDb = GetById(todo.Id);

            if (todoFromDb == null)
                return false;

            if (todoFromDb.Title != todo.Title)
                todoFromDb.Title = todo.Title;
            if (todoFromDb.Description != todo.Description)
                todoFromDb.Description = todo.Description;

            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var todo = GetById(id);
            if (todo == null)
                return false;
            _dbContext.Todos.Remove(todo);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
