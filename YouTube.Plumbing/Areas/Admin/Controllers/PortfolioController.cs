using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstract;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {
       private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<IActionResult> GetPortfolioList()
        {
            var portfoliotList = await _portfolioService.GetAllListAsync();
            return View(portfoliotList);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPortfolio(PortfolioAddVM portfolioAddVM)
        {
            await _portfolioService.AddPortfolioAsync(portfolioAddVM);
            return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePortfolio(int id)
        {
            var portfolio = await _portfolioService.GetPortfolioById(id);
            return View(portfolio);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePortfolio(PortfolioUpdateVM portfolioUpdateVM)
        {
            await _portfolioService.UpdatePortfolioAsync(portfolioUpdateVM);
            return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeletePortfolio(int id)
        {
            await _portfolioService.DeletePortfolioAsync(id);
            return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
        }
    }
}
