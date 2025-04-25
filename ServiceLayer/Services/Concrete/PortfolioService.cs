﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.UnitOfWorks.Abstract;
using ServiceLayer.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Concrete
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Portfolio> _repository;

        public PortfolioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Portfolio>();
        }
        public async Task AddPortfolioAsync(PortfolioAddVM request)
        {
            var portfolio = _mapper.Map<Portfolio>(request);
            await _repository.AddEntityAsync(portfolio);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeletePortfolioAsync(int id)
        {
            var portfolio = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(portfolio);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<PortfolioListVM>> GetAllListAsync()
        {
            var portfolioListVM = await _repository.GetAllEntityList().
                ProjectTo<PortfolioListVM>(_mapper.ConfigurationProvider).ToListAsync();

            return portfolioListVM;
        }

        public async Task<PortfolioUpdateVM> GetPortfolioById(int id)
        {
            var portfolio = await _repository.Where(x => x.Id == id).ProjectTo<PortfolioUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return portfolio;
        }

        public async Task UpdatePortfolioAsync(PortfolioUpdateVM request)
        {
            var portfolio = _mapper.Map<Portfolio>(request);
            _repository.UpdateEntity(portfolio);
            await _unitOfWork.CommitAsync();
        }
    }
}
