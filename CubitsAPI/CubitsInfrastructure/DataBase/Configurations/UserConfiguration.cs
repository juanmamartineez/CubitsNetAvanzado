using CubitsDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CubitsInfrastructure.DataBase.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Name)
                .HasColumnName("firstname");
            builder.Property(user => user.LastName)
                .HasColumnName("lastname");
            builder.Property(user => user.Dni)
                .HasColumnName("dni");
            builder.Property(user => user.Age)
                .HasColumnName("age");
        }
    }
}