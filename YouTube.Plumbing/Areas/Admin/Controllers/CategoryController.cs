using EntityLayer.WebApplication.ViewModels.CategoryVM;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YouTube.Plumbing.ServiceLayer.Services.WebApplication.Abstract;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IValidator<CategoryAddVM> _addValidator;
        private readonly IValidator<CategoryUpdateVM> _updateValidator;

        public CategoryController(ICategoryService categoryService, IValidator<CategoryAddVM> addValidator, IValidator<CategoryUpdateVM> updateValidator)
        {
            _categoryService = categoryService;
            _addValidator = addValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IActionResult> GetCategoryList()
        {
            var categorytList = await _categoryService.GetAllListAsync();
            return View(categorytList);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryAddVM categoryAddVM)
        {
            var validator = await _addValidator.ValidateAsync(categoryAddVM);
            if (validator.IsValid)
            {
                await _categoryService.AddCategoryAsync(categoryAddVM);
                return RedirectToAction("GetCategoryList", "Category", new { Area = ("Admin") });
            }
            validator.AddToModelState(this.ModelState);
            return View();
           
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateVM categoryUpdateVM)
        {
            var validator = await _updateValidator.ValidateAsync(categoryUpdateVM);
            if(validator.IsValid)
            {
                await _categoryService.UpdateCategoryAsync(categoryUpdateVM);
                return RedirectToAction("GetCategoryList", "Category", new { Area = ("Admin") });
            }
            validator.AddToModelState(this.ModelState);
            return View();
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("GetCategoryList", "Category", new { Area = ("Admin") });
        }
    }
}
