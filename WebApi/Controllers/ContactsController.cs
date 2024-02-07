using Microsoft.AspNetCore.Http;
using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WebApi.Controllers
{
    [Route("contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly IUploadService _uploadService;

        public ContactsController(ContactFakeDb fakeDb)
        {
            _fakeDb = fakeDb;
        }

        [HttpGet]
        public IActionResult Get ([FromQuery] string? nameFilter, [FromQuery] string? lastnameFilter)
        {
            var contacts = _fakeDb.Contacts;

            if (!string.IsNullOrEmpty(nameFilter))
            {
                contacts = contacts.Where(c => c.Name != null && c.Name.Contains(nameFilter, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(lastnameFilter))
            {
                contacts = contacts.Where(c => c.Lastname != null && c.Lastname.Contains(lastnameFilter, StringComparison.OrdinalIgnoreCase)).ToList();
            }


            if (contacts.Any())
            {
                return Ok(contacts);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _fakeDb.Contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
                return NotFound(new
                {
                    Message = "Contact non trouvé !"
                });

            return Ok(new
            {
                Message = "Contact trouvé !",
                Contact = contact
            });
        }

        [HttpGet("name/{lastname}")]
        public IActionResult GetByLastName(string lastname)
        {
            var contact = _fakeDb.Contacts.FirstOrDefault(l => l.Lastname == lastname);

            if (contact == null)
                return NotFound(new
                {
                    Message = "Contact non trouvé !"
                });

            return Ok(new
            {
                Message = "Contact trouvé !",
                Contact = contact
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
                {
            _fakeDb.Contacts.Add(contact);
            return CreatedAtAction(nameof(GetById), new { id = contact.Id }, "Contact ajouté");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, [FromBody] Contact updatedcontact)
        {
            var contact = _fakeDb.Contacts.FirstOrDefault(u => u.Id == id);

            if (contact == null)
                return NotFound(new
                {
                    Message = "Contact non trouvé !"
                });


            contact.Name = updatedcontact.Name ?? contact.Name;
            contact.Lastname = updatedcontact.Lastname ?? contact.Lastname;
            contact.BirthDate = updatedcontact.BirthDate ?? contact.BirthDate;
            contact.Gender = updatedcontact.Gender ?? contact.Gender;

            return Ok(new
            {
                Message = "Contact modifié !",
                UpdatedContact = contact
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var contact = _fakeDb.Contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
                return NotFound(new
                {
                    Message = "Contact non trouvé !"
                });

            _fakeDb.Contacts.Remove(contact);

            return Ok(new
            {
                Message = "Contact supprimé !",
                DeletedContact = contact
            });
        }
    }
}
