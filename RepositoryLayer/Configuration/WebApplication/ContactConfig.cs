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
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Location).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Call).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Map).IsRequired();

            builder.HasData(new Contact
            {
                Id = 1,
                CreatedDate = "05/05/2025",
                Location = "AQSh Street, Nyu York",
                Email = "test@gmail.com",
                Call = "+998904417805",
                Map = "TestLink Here"
            });

        }
    }
}
