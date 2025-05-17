using EntityLayer.WebApplication.ViewModels.CategoryVM;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstract;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
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
            await _categoryService.AddCategoryAsync(categoryAddVM);
            return RedirectToAction("GetCategoryList", "Category", new { Area = ("Admin") });
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
            await _categoryService.UpdateCategoryAsync(categoryUpdateVM);
            return RedirectToAction("GetCategoryList", "Category", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("GetCategoryList", "Category", new { Area = ("Admin") });
        }
    }
}
