﻿using AutoMapper;
using EntityLayer.Identity.Entities;
using EntityLayer.Identity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper.Identity
{
    public class SignUpMapper : Profile
    {
        public SignUpMapper()
        {
            CreateMap<AppUser, SignUpVM>().ReverseMap();
        }
    }
}
