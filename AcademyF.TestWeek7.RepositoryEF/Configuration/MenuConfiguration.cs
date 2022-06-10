using AcademyF.TestWeek7.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.TestWeek7.RepositoryEF.Configuration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired();

            //Relazione Menu 1 ->Dish n
            builder.HasMany(m => m.Dishes).WithOne(d => d.Menu).HasForeignKey(d => d.MenuId);
        }
    }
}
