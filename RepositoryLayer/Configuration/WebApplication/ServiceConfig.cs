using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configuration.WebApplication
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.Icon).IsRequired().HasMaxLength(100);

            builder.HasData(new Service
            {
                Id = 1,
                CreatedDate = "05/05/2025",
                Name = "Plumbing Service1",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
               "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Icon = "Bi Bi-service 1"
            }, new Service
            {
                Id = 2,
                CreatedDate = "05/05/2025",
                Name = "Plumbing Service2",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
               "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Icon = "Bi Bi-service 2"
            }, new Service
            {
                Id = 3,
                CreatedDate = "05/05/2025",
                Name = "Plumbing Service3",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
               "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Icon = "Bi Bi-service 3"
            });
        }
    }
}
