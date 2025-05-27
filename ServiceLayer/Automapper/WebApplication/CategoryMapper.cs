using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.CategoryVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper.WebApplication
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryAddVM>().ReverseMap();
            CreateMap<Category, CategoryListVM>().ReverseMap();
            CreateMap<Category, CategoryUpdateVM>().ReverseMap();
        }
    }
}
