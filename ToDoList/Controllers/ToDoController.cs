using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ToDoList.Controllers
{
    public class TodoController : Controller
    {
        private readonly IRepository<Todo> _todoRepository;

        public TodoController(

            IRepository<Todo> todoRepository
            )
        {
            _todoRepository = todoRepository;
        }

        public IActionResult Index()
        {
            return View(_todoRepository.GetAll());
        }

        public IActionResult Details(int id)
        {
            return View(_todoRepository.GetById(id));
        }


        public IActionResult Form(int id)
        {
            if (id == 0)
                return View();
            var todo = _todoRepository.GetById(id);
            return View(todo);
        }

        public IActionResult SubmitTodo(Todo todo)
        {
            if (todo.Id == 0)
                _todoRepository.Add(todo);
            else
                _todoRepository.Update(todo);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _todoRepository.Delete(id);
            return RedirectToAction(nameof(Index));

        }

        [NonAction]
        public static string RandomString(string chars, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
