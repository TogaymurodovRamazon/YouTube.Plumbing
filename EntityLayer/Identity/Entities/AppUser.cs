﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Identity.Entities
{
    public class AppUser : IdentityUser
    {
        public string? FileName { get; set; }
        public string? FileType { get; set; }
    }
}
