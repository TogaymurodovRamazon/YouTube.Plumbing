﻿using EntityLayer.WebApplication.ViewModels.ServiceVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube.Plumbing.ServiceLayer.Services.WebApplication.Abstract
{
    public interface IServiceService
    {
        Task<List<ServiceListVM>> GetAllListAsync();
        Task AddServiceAsync(ServiceAddVM request);
        Task DeleteServiceAsync(int id);
        Task<ServiceUpdateVM> GetServiceById(int id);
        Task UpdateServiceAsync(ServiceUpdateVM request);
    }
}
