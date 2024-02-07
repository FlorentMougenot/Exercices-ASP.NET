using WebApi.Data;
using WebApi.Models;
using System.Linq.Expressions;

namespace WebApi.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private ApplicationDbContext _dbContext;
        public ContactRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(Contact contact)
        {
            var addedcontact = _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();
            return addedcontact.Entity.Id > 0;
        }

        public Contact? GetById(int id)
        {
            return _dbContext.Contacts.Find(id);
        }
        public Contact? Get(Expression<Func<Contact, bool>> predicate)
        {
            return _dbContext.Contacts.FirstOrDefault(predicate);
        }
        public List<Contact> GetAll()
        {
            return _dbContext.Contacts.ToList();
        }
        public List<Contact> GetAll(Expression<Func<Contact, bool>> predicate)
        {
            return _dbContext.Contacts.Where(predicate).ToList();
        }

        public bool Update(Contact contact)
        {
            var contactFromDb = GetById(contact.Id);

            if (contactFromDb == null)
                return false;

            if (contactFromDb.Name != contact.Name)
                contactFromDb.Name = contact.Name;
            if (contactFromDb.Lastname != contact.Lastname)
                contactFromDb.Lastname = contact.Lastname;
            if (contactFromDb.BirthDate != contact.BirthDate)
                contactFromDb.BirthDate = contact.BirthDate;
            if (contactFromDb.Gender != contact.Gender)
                contactFromDb.Gender = contact.Gender;

            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var contact = GetById(id);
            if (contact == null)
                return false;
            _dbContext.Contacts.Remove(contact);
            return _dbContext.SaveChanges() > 0;
        }
    }
}

