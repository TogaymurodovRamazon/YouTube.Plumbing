﻿using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configuration.WebApplication
{
    public class SocialMediaConfig : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasData(new SocialMedia
            {
                Id = 1,
                CreatedDate = "05/05/2025",
                Faceboook = "testFacebook",
                Instagram = "testInstagram",
            });
        }
    }
}
