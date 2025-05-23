﻿using EntityLayer.WebApplication.ViewModels.AboutVM;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstract;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("Admin/[controller]/[action]")]

    //[Authorize(Policy = "AdminObserver")]
    //[Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> GetAboutList()
        {
            var aboutList = await _aboutService.GetAllListAsync();
            return View(aboutList);
        }

        [HttpGet]
        public IActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAbout(AboutAddVM aboutAddVM)
        {
            await _aboutService.AddAboutAsync(aboutAddVM);
            return RedirectToAction("GetAboutList", "About", new { Area = ("Admin") });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var about = await _aboutService.GetAboutById(id);
            return View(about);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(AboutUpdateVM aboutUpdateVM)
        {
            await _aboutService.UpdateAboutAsync(aboutUpdateVM);
            return RedirectToAction("GetAboutList", "About", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction("GetAboutList", "About", new { Area = ("Admin") });
        }
    }
}
