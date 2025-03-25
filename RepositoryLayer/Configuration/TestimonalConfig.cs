using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Configuration
{
    public class TestimonalConfig : IEntityTypeConfiguration<Testimonal>
    {
        public void Configure(EntityTypeBuilder<Testimonal> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.Property(x => x.Comment).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FileType).IsRequired();

            builder.HasData(new Testimonal
            {
                Id = 1,
                Comment= "Lorem ipsum dolor sit amet, consectetur adipiscing elit," +
                " sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                FullName="Merlin Mariya",
                Title="Interesting",
                FileName="Test",
                FileType="Test",
            }, new Testimonal
            {
                Id = 2,
                Comment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit," +
                " sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                FullName = "Jeki Chan",
                Title = "Interesting",
                FileName = "Test",
                FileType = "Test",
            }, new Testimonal
            {
                Id = 3,
                Comment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit," +
                " sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                FullName = "Brusli",
                Title = "Interesting",
                FileName = "Test",
                FileType = "Test",
            });
        }
    }
}
