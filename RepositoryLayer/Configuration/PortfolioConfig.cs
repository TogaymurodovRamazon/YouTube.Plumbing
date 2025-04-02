﻿using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configuration
{
    public class PortfolioConfig : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            //builder.HasOne(x => x.Category).WithMany(x => x.Portfolios).OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FileType).IsRequired();

            builder.HasData(new Portfolio
            {
                Id = 1,
                CreatedDate = "05/05/2025",
                CategoryId = 1,
                FileName = "Test",
                FileType = "test",
                Title = "Test Picture",
            }, new Portfolio
            {
                Id = 2,
                CreatedDate = "05/05/2025",
                CategoryId = 1,
                FileName = "Test2",
                FileType = "test2",
                Title = "Test Picture2",
            }, new Portfolio
            {
                Id = 3,
                CreatedDate = "05/05/2025",
                CategoryId = 2,
                FileName = "Test3",
                FileType = "test3",
                Title = "Test Picture3",
            }, new Portfolio
            {
                Id = 4,
                CreatedDate = "05/05/2025",
                CategoryId = 2,
                FileName = "Test4",
                FileType = "test4",
                Title = "Test Picture4",
            });
        }
    }
}
