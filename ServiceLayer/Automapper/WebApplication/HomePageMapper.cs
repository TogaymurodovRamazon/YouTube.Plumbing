﻿using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.HomePageVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper.WebApplication
{
    public class HomePageMapper : Profile
    {
        public HomePageMapper()
        {
            CreateMap<HomePage, HomePageAddVM>().ReverseMap();
            CreateMap<HomePage, HomePageListVM>().ReverseMap();
            CreateMap<HomePage, HomePageUpdateVM>().ReverseMap();
        }
    }
}
