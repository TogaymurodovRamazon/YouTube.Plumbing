using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ServiceVM;
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
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Service> _repository;

        public ServiceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Service>();
        }
        public async Task AddServiceAsync(ServiceAddVM request)
        {
            var service = _mapper.Map<Service>(request);
            await _repository.AddEntityAsync(service);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(service);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<ServiceListVM>> GetAllListAsync()
        {
            var serviceListVM = await _repository.GetAllEntityList().
                ProjectTo<ServiceListVM>(_mapper.ConfigurationProvider).ToListAsync();

            return serviceListVM;
        }

        public async Task<ServiceUpdateVM> GetServiceById(int id)
        {
            var service = await _repository.Where(x => x.Id == id).ProjectTo<ServiceUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return service;
        }

        public async Task UpdateServiceAsync(ServiceUpdateVM request)
        {
            var service = _mapper.Map<Service>(request);
            _repository.UpdateEntity(service);
            await _unitOfWork.CommitAsync();
        }
    }
}
