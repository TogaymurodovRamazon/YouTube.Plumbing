﻿using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.ServiceVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper.WebApplication
{
    public class ServiceMapper : Profile
    {
        public ServiceMapper()
        {
            CreateMap<Service, ServiceAddVM>().ReverseMap();
            CreateMap<Service, ServiceListVM>().ReverseMap();
            CreateMap<Service, ServiceUpdateVM>().ReverseMap();
        }
    }
}
