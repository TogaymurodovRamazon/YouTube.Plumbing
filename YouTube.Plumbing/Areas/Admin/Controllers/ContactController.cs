using EntityLayer.WebApplication.ViewModels.ContactVM;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IValidator<ContactAddVM> _addValidator;
        private readonly IValidator<ContactUpdateVM> _updateValidator;

        public ContactController(IContactService contactService, IValidator<ContactAddVM> addValidator, IValidator<ContactUpdateVM> updateValidator)
        {
            _contactService = contactService;
            _addValidator = addValidator;
            _updateValidator = updateValidator;
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
            var validator = await _addValidator.ValidateAsync(contactAddVM);
            if (validator.IsValid)
            {
                await _contactService.AddContactAsync(contactAddVM);
                return RedirectToAction("GetContactList", "Contact", new { Area = ("Admin") });
            }
            validator.AddToModelState(this.ModelState);
            return View();
            
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
            var validator = await _updateValidator.ValidateAsync(contactUpdateVM);
            if (validator.IsValid)
            {
                await _contactService.UpdateContactAsync(contactUpdateVM);
                return RedirectToAction("GetContactList", "Contact", new { Area = ("Admin") });
            }
            validator.AddToModelState(this.ModelState);
            return View();
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            await _contactService.DeleteContactAsync(id);
            return RedirectToAction("GetContactList", "Contact", new { Area = ("Admin") });
        }
    }
}
