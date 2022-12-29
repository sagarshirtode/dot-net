using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContextApiDBContext dbContext;

        public ContactsController(ContextApiDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await dbContext.Contacts.ToListAsync());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetOneContacts([FromRoute] Guid id)
        {
            var getContact = await dbContext.Contacts.FindAsync(id);
            return Ok(getContact);
        }
        [HttpPost]
        public  async Task<IActionResult> AddContacts(AddContactRequest addContactRequest)
        {
            var c = new Contact()
            {
                Id = Guid.NewGuid(),
                Fullname = addContactRequest.Fullname,
                Email = addContactRequest.Email,
                Phone = addContactRequest.Phone,
                Address = addContactRequest.Address,

            };
            await dbContext.Contacts.AddAsync(c);
            await dbContext.SaveChangesAsync();
            return Ok(c);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContacts([FromRoute] Guid id, Contact contact)
        {
            var updatedContact = await dbContext.Contacts.FindAsync(id);
            if (updatedContact != null)
            {
                updatedContact.Fullname = contact.Fullname;
                updatedContact.Email = contact.Email;
                updatedContact.Phone = contact.Phone;
                updatedContact.Address = contact.Address;

                await dbContext.SaveChangesAsync();
                return Ok(updatedContact);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContacts([FromRoute] Guid id)
        {
            var getContact = await dbContext.Contacts.FindAsync(id);
            if (getContact != null)
            {
                dbContext.Remove(getContact);
                await dbContext.SaveChangesAsync();
                return Ok(getContact);
            }
            return NotFound();
        }

    }
}
