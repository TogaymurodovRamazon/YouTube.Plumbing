using EntityLayer.WebApplication.ViewModels.ServiceVM;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstract;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
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
            await _serviceService.AddServiceAsync(serviceAddVM);
            return RedirectToAction("GetServiceList", "Service", new { Area = ("Admin") });
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
            await _serviceService.UpdateServiceAsync(serviceUpdateVM);
            return RedirectToAction("GetServiceList", "Service", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceService.DeleteServiceAsync(id);
            return RedirectToAction("GetServiceList", "Service", new { Area = ("Admin") });
        }
    }
}
