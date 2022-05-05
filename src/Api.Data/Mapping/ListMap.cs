using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ListMap : IEntityTypeConfiguration<ListEntity>
    {
        public void Configure(EntityTypeBuilder<ListEntity> builder)
        {
            builder.ToTable("list");
            builder.HasIndex(l => l.Id);

        }
    }
}
