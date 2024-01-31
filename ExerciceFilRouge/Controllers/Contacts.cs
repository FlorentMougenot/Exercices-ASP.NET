using Microsoft.AspNetCore.Mvc;

namespace ExerciceFilRouge.Controllers
{
    public class Contacts : Controller
    {

        /*public List<string> contacts = new List<string> { "A", "B", "C" };*/
        public IActionResult Index()
        {
            /*            string a = contacts[0];
                        for (int i = 1; i < contacts.Count; i++)
                        {
                            a = a + ", " + contacts[i];
                        }

                            return $"Je suis la page pour afficher les contacts: {a} !";*/
            return View();
        }

        public IActionResult Details(string contact)
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
