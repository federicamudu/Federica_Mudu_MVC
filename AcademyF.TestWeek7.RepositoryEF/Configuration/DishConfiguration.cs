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
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {

        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.ToTable("Dish"); 
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name).IsRequired();
            builder.Property(d => d.Description).IsRequired();
            builder.Property(d => d.Type).IsRequired();
            builder.Property(d => d.Price).IsRequired();

            //Relazione Menu 1 ->Dish n
            builder.HasOne(d => d.Menu).WithMany(m => m.Dishes).HasForeignKey(m => m.Id).IsRequired(false);
        }
    }
}
