using System.Xml.Linq;
using TryDemo.Models;

namespace TryDemo.Data
{
    public class CrepeFakeDb
    {
        public List<Crepe> Crepes { get; set; } = new List<Crepe>()
        {
            new Crepe()
            {
            Id = 1,
            Name = "Surprise du chef",
            Diameter = 14,
            IsSalty = true,
            Topping1 = Topping.Canard,
            Topping2 = Topping.Orange
            },

            new Crepe()
            {
            Id = 2,
            Name = "Grand chamboulement",
            Diameter = 16,
            IsSalty = true,
            Topping1 = Topping.Crevettes,
            Topping2 = Topping.Nutella
            },
        };
    }
}
