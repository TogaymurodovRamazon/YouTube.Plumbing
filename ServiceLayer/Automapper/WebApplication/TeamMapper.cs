﻿using AutoMapper;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.TeamVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper.WebApplication
{
    public class TeamMapper : Profile
    {
        public TeamMapper()
        {
            CreateMap<Team, TeamAddVM>().ReverseMap();
            CreateMap<Team, TeamListVM>().ReverseMap();
            CreateMap<Team, TeamUpdateVM>().ReverseMap();
        }
    }
}
