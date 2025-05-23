﻿using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.SocialMediaVM
{
    public class SocialMediaUpdateVM
    {
        public int Id { get; set; }
        public string? UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; } = null!;

        public string? Twitter { get; set; }
        public string? LinkedIn { get; set; }
        public string? Faceboook { get; set; }
        public string? Instagram { get; set; }

        public AboutUpdateVM About { get; set; } = null!;
    }
}
