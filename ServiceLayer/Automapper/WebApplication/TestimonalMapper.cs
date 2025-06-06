﻿using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.TestimonalVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper.WebApplication
{
    public class TestimonalMapper : Profile
    {
        public TestimonalMapper()
        {
            CreateMap<Testimonal, TestimonalAddVM>().ReverseMap();
            CreateMap<Testimonal, TestimonalListVM>().ReverseMap();
            CreateMap<Testimonal, TestimonalUpdateVM>().ReverseMap();
        }
    }
}
