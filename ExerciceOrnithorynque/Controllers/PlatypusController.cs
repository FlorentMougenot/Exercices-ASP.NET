using ExerciceOrnithorynque.Data;
using ExerciceOrnithorynque.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExerciceOrnithorynque.Controllers
{
    public class PlatypusController : Controller
    {   
        private FakePlatypusDb _fakePlatypusDb;

        private static List<string> MixedNames = new List<string>
{
    "Liam", "Olivia", "Noah", "Emma", "Oliver", "Ava", "Elijah", "Sophia", "William", "Isabella",
    "James", "Mia", "Benjamin", "Amelia", "Lucas", "Harper", "Henry", "Evelyn", "Alexander", "Abigail",
    "Sebastian", "Emily", "Michael", "Charlotte", "Daniel", "Luna", "Matthew", "Ella", "Jackson", "Grace",
    "Logan", "Chloe", "David", "Avery", "Joseph", "Mila", "Samuel", "Eleanor", "Christopher", "Scarlett",
    "John", "Madison", "Dylan", "Aria", "Nicholas", "Lily", "Caleb", "Hannah", "Ryan", "Nora",
    "Andrew", "Sofia", "Isaac", "Penelope", "Gabriel", "Addison", "Nathan", "Victoria", "Ethan", "Layla",
    "Carter", "Brooklyn", "Christian", "Zoey", "Joshua", "Stella", "Jonathan", "Violet", "Connor", "Aurora",
    "Eli", "Savannah", "Matthew", "Audrey", "Isaiah", "Claire", "Brayden", "Bella", "Aaron", "Skylar"
};

        public PlatypusController(FakePlatypusDb fakePlatypusDb)
        {
            _fakePlatypusDb = fakePlatypusDb;
        }

        public IActionResult Index()
        {
            return View(_fakePlatypusDb.GetAll());
        }

        public IActionResult Details(int id)
        {
            Platypus? platypus = _fakePlatypusDb.GetById(id);

            return View(platypus);
        }

        public IActionResult Delete(int id)
        {
             _fakePlatypusDb.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddJD()
        {
            Platypus? canardator = new Platypus()
            {
                Name = "Joe Dalton",
                Size = 666,
                Weight = 1666.66,
                CanSwim = false
            };

            _fakePlatypusDb.Add(canardator);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult AddList(Platypus platypus)
        {
            _fakePlatypusDb.Add(platypus);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AddRandom()
        {
            Random random = new Random();

            Platypus randomPlatypus = new Platypus()
            {
                Name = MixedNames[random.Next(MixedNames.Count)],
                Size = random.Next(50, 100),
                Weight = Math.Round(random.NextDouble() * (2.5 - 0.5) + 0.5, 2),
                CanSwim = random.Next(0, 2) == 1
            };

            
            _fakePlatypusDb.Add(randomPlatypus);

            return RedirectToAction(nameof(Index));
        }
    }
}
