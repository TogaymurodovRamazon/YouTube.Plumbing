﻿using EntityLayer.WebApplication.ViewModels.CategoryVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube.Plumbing.ServiceLayer.Services.WebApplication.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryListVM>> GetAllListAsync();
        Task AddCategoryAsync(CategoryAddVM request);
        Task DeleteCategoryAsync(int id);
        Task<CategoryUpdateVM> GetCategoryById(int id);
        Task UpdateCategoryAsync(CategoryUpdateVM request);
    }
}
