using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.WebApplication.ViewModels.SocialMediaVM
{
    public class SocialMediaAddVM
    {
        public string? Twitter { get; set; }
        public string? LinkedIn { get; set; }
        public string? Faceboook { get; set; }
        public string? Instagram { get; set; }

        public AboutAddVM About { get; set; } = null!;
    }
}
