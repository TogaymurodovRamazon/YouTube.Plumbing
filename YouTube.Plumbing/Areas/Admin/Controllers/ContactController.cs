using EntityLayer.WebApplication.ViewModels.AboutVM;
using EntityLayer.WebApplication.ViewModels.ContactVM;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstract;
using ServiceLayer.Services.Concrete;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
       private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> GetContactList()
        {
            var contactList = await _contactService.GetAllListAsync();
            return View(contactList);
        }

        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddContact(ContactAddVM contactAddVM)
        {
            await _contactService.AddContactAsync(contactAddVM);
            return RedirectToAction("GetContactList", "Contact", new { Area = ("Admin") });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var contact = await _contactService.GetContactById(id);
            return View(contact);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(ContactUpdateVM contactUpdateVM)
        {
            await _contactService.UpdateContactAsync(contactUpdateVM);
            return RedirectToAction("GetContactList", "Contact", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactService.DeleteContactAsync(id);
            return RedirectToAction("GetContactList", "Contact", new { Area = ("Admin") });
        }
    }
}
