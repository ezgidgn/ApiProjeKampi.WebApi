using ApiProjeKampi.WebApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiProjeKampi.WebApi.Dtos;
using ApiProjeKampi.WebApi.Entites;

namespace ApiProjeKampi.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;
        public ContactsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var contact = _context.Contacts.ToList();
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact();
            contact.MapLocation = createContactDto.MapLocation;
            contact.Email = createContactDto.Email;
            contact.Address = createContactDto.Address;
            contact.Phone = createContactDto.Phone;
            contact.OpenHours = createContactDto.OpenHours;

            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("İletişim bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _context.Contacts.Find(id); //id den gelen değeri bul
            if (contact == null)
            {
                return NotFound("İletişim bilgisi bulunamadı");
            }
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return Ok("İletişim bilgisi silindi");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound("İletişim bilgisi bulunamadı");
            }
            return Ok(contact);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            if (updateContactDto == null)
            {
                return BadRequest("Geçersiz iletişim verisi");
            }
            var contact = _context.Contacts.Find(updateContactDto);
            if (contact == null)
            {
                return NotFound("İletişim bilgisi bulunamadı");
            }
            contact.MapLocation = updateContactDto.MapLocation;
            contact.Email = updateContactDto.Email;
            contact.Address = updateContactDto.Address;
            contact.Phone = updateContactDto.Phone;
            contact.OpenHours = updateContactDto.OpenHours;

            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("İletişim bilgisi güncellendi");
        }
}
}