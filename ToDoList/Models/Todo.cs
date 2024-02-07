using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models;
    public class Todo
{
    public int Id { get; set; }
    [Display(Name = "Titre de la tâche")]
    public string? Title { get; set; }
    [Display(Name = "Description de la tâche")]
    public string? Description { get; set; }
}
