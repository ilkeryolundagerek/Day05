using Core.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
               .HasKey(x => x.Id); //Primary Key tanımı.

            builder
                .Property(x => x.Id)
                .UseIdentityColumn(); //Identity(1,1)/AutoIncrement tanımı

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Category)
                .IsRequired(false)
                .HasMaxLength(15);

            builder
                .HasOne(x => x.Person)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.PersonId);

            builder
                .ToTable("Item", "HR");
        }
    }
}
