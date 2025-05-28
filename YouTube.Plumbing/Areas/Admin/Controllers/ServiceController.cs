using EntityLayer.WebApplication.ViewModels.ServiceVM;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IValidator<ServiceAddVM> _addValidator;
        private readonly IValidator<ServiceUpdateVM> _updateValidator;

        public ServiceController(IServiceService serviceService, IValidator<ServiceAddVM> addValidator, IValidator<ServiceUpdateVM> updateValidator)
        {
            _serviceService = serviceService;
            _addValidator = addValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IActionResult> GetServiceList()
        {
            var serviceList = await _serviceService.GetAllListAsync();
            return View(serviceList);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(ServiceAddVM serviceAddVM)
        {
            var validator= await _addValidator.ValidateAsync(serviceAddVM);
            if (validator.IsValid)
            {
                await _serviceService.AddServiceAsync(serviceAddVM);
                return RedirectToAction("GetServiceList", "Service", new { Area = ("Admin") });
            }
            validator.AddToModelState(this.ModelState);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var service = await _serviceService.GetServiceById(id);
            return View(service);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(ServiceUpdateVM serviceUpdateVM)
        {
            var validator = await _updateValidator.ValidateAsync(serviceUpdateVM);
            if(validator.IsValid)
            {
                await _serviceService.UpdateServiceAsync(serviceUpdateVM);
                return RedirectToAction("GetServiceList", "Service", new { Area = ("Admin") });
            }
            validator.AddToModelState(this.ModelState);
            return View();
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceService.DeleteServiceAsync(id);
            return RedirectToAction("GetServiceList", "Service", new { Area = ("Admin") });
        }
    }
}
