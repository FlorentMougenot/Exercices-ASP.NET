using ExerciceOrnithorynque.Models;

namespace ExerciceOrnithorynque.Data
{
    public class FakePlatypusDb
    {
        private List<Platypus> _platypus;
        private int _lastId = 0;

        public FakePlatypusDb()
        {
            _platypus = new List<Platypus>()
            {
                new Platypus { Id = ++_lastId, Name = "Coin", Size=60, Weight=1.50, CanSwim=true},
                new Platypus { Id = ++_lastId, Name = "Coincoin", Size=55, Weight=1.24, CanSwim=true},
                new Platypus { Id = ++_lastId, Name = "Koinkoin", Size=55, Weight=1.32, CanSwim=false},
            };
        }

        public List<Platypus> GetAll()
        {
            return _platypus;
        }

        public Platypus? GetById(int id)
        {
            return _platypus.FirstOrDefault(p => p.Id == id);
        }

        public bool Add(Platypus platypus)
        {
            platypus.Id = ++_lastId;
            _platypus.Add(platypus);
            return true;
        }

        public bool Edit(Platypus platypus)
        {
            var platyFromDb = GetById(platypus.Id);
            if (platyFromDb == null)
                return false;
            platyFromDb.Name = platypus.Name;
            platyFromDb.Size = platypus.Size;
            platyFromDb.Weight = platypus.Weight;
            platyFromDb.CanSwim = platypus.CanSwim;

            return true;
        }
        public bool Delete(int id)
        {
            var platypus = GetById(id);
            if (platypus == null)
                return false;
            _platypus.Remove(platypus);
            return true;
        }
    }
}
