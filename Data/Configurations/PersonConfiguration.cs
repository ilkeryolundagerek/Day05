using Core.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder
                .HasKey(x => x.Id); //Primary Key tanımı.

            builder
                .Property(x => x.Id)
                .UseIdentityColumn(); //Identity(1,1)/AutoIncrement tanımı

            builder
                .Property(x => x.Firstname)
                .IsRequired()
                .HasMaxLength(25);

            builder
                .Property(x => x.Middlename)
                .HasMaxLength(25);

            builder
                .Property(x => x.Lastname)
                .IsRequired()
                .HasMaxLength(25);

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.People)
                .HasForeignKey(x => x.DepartmentId); //Foreign Key

            builder
                .ToTable("Person", "HR");//Tablo adı ve Şema (Schema)
        }
    }
}
