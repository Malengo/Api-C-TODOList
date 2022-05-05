using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.HasIndex(u => u.Id);
            builder.Property(u => u.Name)
                  .IsRequired()
                  .HasMaxLength(70);
            builder.HasIndex(u => u.Email)
                    .IsUnique();
            builder.Property(u => u.Senha)
                    .HasMaxLength(8);


        }
    }
}
