using EntityLayer.WebApplication.ViewModels.HomePageVM;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageController : Controller
    {
        private readonly IHomePageService _homePageService;
        public HomePageController(IHomePageService homePageService)
        {
            _homePageService = homePageService;
        }

        public async Task<IActionResult> GetHomePageList()
        {
            var homePageList = await _homePageService.GetAllListAsync();
            return View(homePageList);
        }

        [HttpGet]
        public IActionResult AddHomePage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHomePage(HomePageAddVM homePageAddVM)
        {
            await _homePageService.AddHomePageAsync(homePageAddVM);
            return RedirectToAction("GetHomePageList", "HomePage", new { Area = ("Admin") });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateHomePage(int id)
        {
            var homePage = await _homePageService.GetHomePageById(id);
            return View(homePage);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateHomePage(HomePageUpdateVM homePageUpdateVM)
        {
            await _homePageService.UpdateHomePageAsync(homePageUpdateVM);
            return RedirectToAction("GetHomePageList", "HomePage", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteHomePage(int id)
        {
            await _homePageService.DeleteHomePageAsync(id);
            return RedirectToAction("GetHomePageList", "HomePage", new { Area = ("Admin") });
        }
    }
}
