﻿using EntityLayer.WebApplication.ViewModels.SocialMediaVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTube.Plumbing.ServiceLayer.Services.WebApplication.Abstract
{
    public interface ISocialMediaService
    {
        Task<List<SocialMediaListVM>> GetAllListAsync();
        Task AddSocialMediaAsync(SocialMediaAddVM request);
        Task DeleteSocialMediaAsync(int id);
        Task<SocialMediaUpdateVM> GetSocialMediaById(int id);
        Task UpdateSocialMediaAsync(SocialMediaUpdateVM request);
    }
}
