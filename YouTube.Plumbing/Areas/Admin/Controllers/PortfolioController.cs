using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using YouTube.Plumbing.ServiceLayer.Services.WebApplication.Abstract;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IValidator<PortfolioAddVM> _addValidator;
        private readonly IValidator<PortfolioUpdateVM> _updateValidator;

        public PortfolioController(IPortfolioService portfolioService, IValidator<PortfolioAddVM> addValidator, IValidator<PortfolioUpdateVM> updateValidator)
        {
            _portfolioService = portfolioService;
            _addValidator = addValidator;
            _updateValidator = updateValidator;
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
            var validator = await _addValidator.ValidateAsync(portfolioAddVM);
            if (validator.IsValid)
            {
                await _portfolioService.AddPortfolioAsync(portfolioAddVM);
                return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
            }
            validator.AddToModelState(this.ModelState);
            return View();
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
            var validator = await _updateValidator.ValidateAsync(portfolioUpdateVM);
            if(validator.IsValid)
            {
                await _portfolioService.UpdatePortfolioAsync(portfolioUpdateVM);
                return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
            }
            validator.AddToModelState(this.ModelState);
            return View();
        }

        public async Task<IActionResult> DeletePortfolio(int id)
        {
            await _portfolioService.DeletePortfolioAsync(id);
            return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
        }
    }
}
