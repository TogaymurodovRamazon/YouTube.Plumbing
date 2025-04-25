using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.TeamVM;
using EntityLayer.WebApplication.ViewModels.TestimonalVM;
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
    public class TestimonalService : ITestimonalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IGenericRepositories<Testimonal> _repository;

        public TestimonalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = _unitOfWork.GetGenericRepository<Testimonal>();
        }
        public async Task AddTestimonalAsync(TestimonalAddVM request)
        {
            var testimonal = _mapper.Map<Testimonal>(request);
            await _repository.AddEntityAsync(testimonal);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteTestimonalAsync(int id)
        {
            var testimonal = await _repository.GetEntityByIdAsync(id);
            _repository.DeleteEntity(testimonal);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<TestimonalListVM>> GetAllListAsync()
        {
            var testimonalListVM = await _repository.GetAllEntityList().
                ProjectTo<TestimonalListVM>(_mapper.ConfigurationProvider).ToListAsync();

            return testimonalListVM;
        }

        public async Task<TestimonalUpdateVM> GetTestimonalById(int id)
        {
            var testimonal = await _repository.Where(x => x.Id == id).ProjectTo<TestimonalUpdateVM>
                (_mapper.ConfigurationProvider).SingleAsync();
            return testimonal;
        }

        public async Task UpdateTestimonalAsync(TestimonalUpdateVM request)
        {
            var testimonal = _mapper.Map<Testimonal>(request);
            _repository.UpdateEntity(testimonal);
            await _unitOfWork.CommitAsync();
        }
    }
}
