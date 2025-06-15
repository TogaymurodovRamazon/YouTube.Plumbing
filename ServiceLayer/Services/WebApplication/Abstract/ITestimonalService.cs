using EntityLayer.WebApplication.ViewModels.TestimonalVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube.Plumbing.ServiceLayer.Services.WebApplication.Abstract
{
    public interface ITestimonalService
    {
        Task<List<TestimonalListVM>> GetAllListAsync();
        Task AddTestimonalAsync(TestimonalAddVM request);
        Task DeleteTestimonalAsync(int id);
        Task<TestimonalUpdateVM> GetTestimonalById(int id);
        Task UpdateTestimonalAsync(TestimonalUpdateVM request);
    }
}
