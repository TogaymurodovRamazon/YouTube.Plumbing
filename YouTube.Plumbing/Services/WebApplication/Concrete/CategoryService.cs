﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.CategoryVM;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Services.WebApplication.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.WebApplication.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Category> _repository;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Category>();
        }
        public async Task AddCategoryAsync(CategoryAddVM request)
        {
            var category = _mapper.Map<Category>(request);
            await _repository.AddEntityAsync(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(category);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<CategoryListVM>> GetAllListAsync()
        {
            var categoryListVM = await _repository.GetAllEntityList().
                ProjectTo<CategoryListVM>(_mapper.ConfigurationProvider).ToListAsync();

            return categoryListVM;
        }

        public async Task<CategoryUpdateVM> GetCategoryById(int id)
        {
            var category = await _repository.Where(x => x.Id == id).ProjectTo<CategoryUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return category;
        }

        public async Task UpdateCategoryAsync(CategoryUpdateVM request)
        {
            var category = _mapper.Map<Category>(request);
            _repository.UpdateEntity(category);
            await _unitOfWork.CommitAsync();
        }
    }
}
