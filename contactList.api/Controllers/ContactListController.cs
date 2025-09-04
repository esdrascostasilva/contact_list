using contactList.api.Models;
using contactList.api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace contactList.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactListController : ControllerBase
    {
        private readonly IContactListService _contactService;

        public ContactListController(IContactListService contactList)
        {
            _contactService = contactList;
        }

        [HttpGet]
        public async Task<ActionResult<ContactPerson>> GetAllContacts()
        {
            var contacts = await _contactService.GetAllContactsAsync();

            return Ok(contacts);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ContactPerson>> GetContactByName([FromRoute] string name)
        {
            var contacts = await _contactService.GetContactByNameAsync(name);

            return Ok(contacts);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseContactPerson>> CreateContact([FromBody] ContactPerson requestContact)
        {
            var contact = await _contactService.CreateContactAsync(requestContact);

            return CreatedAtAction(nameof(GetContactByName), contact);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(Guid id, [FromBody] ContactPerson requestContact)
        {
            await _contactService.UpdateContactAsync(id, requestContact);

            return Ok("Contato atualizado.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            await _contactService.DeleteContactAsync(id);

            return NoContent();
        }
    }
}
