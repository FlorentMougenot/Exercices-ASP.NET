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
    public class ContactController : ControllerBase
    {
        private readonly IRepository<Contact> _repository;

        public ContactController(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll(string? startLastName)
        {
            if (startLastName == null)
                return Ok(_repository.GetAll());

            return Ok(
                _repository.GetAll(c => c.Lastname!.ToLower().StartsWith(startLastName.ToLower())));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contact = _repository.Get(id);


            if (contact == null)
                return NotFound(new
                {
                    Message = "There is no Contact with this Id."
                });

            return Ok(new
            {
                Message = "Contact found.",
                Contact = contact
            });
        }

        [HttpGet("name/{firstname}")]
        public IActionResult GetByFirstName(string firstname)
        {
            var contact = _repository.Get(c => c.Name == firstname);

            if (contact == null)
                return NotFound(new
                {
                    Message = "There is no Contact with this Firstname."
                });

            return Ok(new
            {
                Message = "Contact found.",
                Contact = contact
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
        {
            var contactAdded = _repository.Add(contact);

            if (contactAdded != null)
                return CreatedAtAction(nameof(GetById),
                                       new { id = contactAdded.Id },
                                       new
                                       {
                                           Message = "Contact Added.",
                                           Contact = contactAdded
                                       });

            return BadRequest("Something went wrong...");
        }


        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Contact contact)
        {
            var contactFromDb = _repository.Get(id);
            if (contactFromDb == null)
                return NotFound("There is no Contact with this Id.");
            contact.Id = id;
            var contactUpdated = _repository.Update(contact);
            if (contactUpdated != null)
                return Ok(new
                {
                    Message = "Contact Updated.",
                    Contact = contactUpdated
                });
            return BadRequest("Something went wrong...");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_repository.Delete(id))
                return Ok("Contect Deleted");
            return BadRequest("Something went wrong...");
        }

    }

    /*    [Route("contacts")]
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
            _repository.Add(contact);
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
}*/
}
