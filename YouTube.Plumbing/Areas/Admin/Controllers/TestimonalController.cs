using EntityLayer.WebApplication.ViewModels.TestimonalVM;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using YouTube.Plumbing.ServiceLayer.Services.WebApplication.Abstract;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonalController : Controller
    {
        private readonly ITestimonalService _testimonalService;
        private readonly IValidator<TestimonalAddVM> _addValidator;
        private readonly IValidator<TestimonalUpdateVM> _updateValidator;

        public TestimonalController(ITestimonalService testimonalService, IValidator<TestimonalAddVM> addValidator, IValidator<TestimonalUpdateVM> updateValidator)
        {
            _testimonalService = testimonalService;
            _addValidator = addValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IActionResult> GetTestimonalList()
        {
            var testimonalList = await _testimonalService.GetAllListAsync();
            return View(testimonalList);
        }

        [HttpGet]
        public IActionResult AddTestimonal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonal(TestimonalAddVM testimonalAddVM)
        {
            var validator = await _addValidator.ValidateAsync(testimonalAddVM);
            if (validator.IsValid)
            {
                await _testimonalService.AddTestimonalAsync(testimonalAddVM);
                return RedirectToAction("GetTestimonalList", "Testimonal", new { Area = ("Admin") });
            }
            validator.AddToModelState(this.ModelState);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonal(int id)
        {
            var testimonal = await _testimonalService.GetTestimonalById(id);
            return View(testimonal);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonal(TestimonalUpdateVM testimonalUpdateVM)
        {
            var validator= await _updateValidator.ValidateAsync(testimonalUpdateVM);
            if (validator.IsValid)
            {
                await _testimonalService.UpdateTestimonalAsync(testimonalUpdateVM);
                return RedirectToAction("GetTestimonalList", "Testimonal", new { Area = ("Admin") });
            }
            validator.AddToModelState(this.ModelState);
            return View();
        }

        public async Task<IActionResult> DeleteTestimonal(int id)
        {
            await _testimonalService.DeleteTestimonalAsync(id);
            return RedirectToAction("GetTestimonalList", "Testimonal", new { Area = ("Admin") });
        }
    }
}
