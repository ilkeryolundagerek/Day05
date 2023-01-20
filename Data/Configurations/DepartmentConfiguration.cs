using Core.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
               .HasKey(x => x.Id); //Primary Key tanımı.

            builder
                .Property(x => x.Id)
                .UseIdentityColumn(); //Identity(1,1)/AutoIncrement tanımı

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder
                .Property(x => x.Description)
                .HasMaxLength(500);

            builder
                .ToTable("Department", "HR");//Tablo adı ve Şema (Schema: Bu yapı sqlerver için şart değil temiz olmaktadır, oracle gibi sistemler için zorunludur.)
        }
    }
}
