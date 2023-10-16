using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EsShop.Domain.Entities;

namespace EsShop.Infrastructure.Context.EntitiesConfiguration;

public class FabricEntityConfiguration : IEntityTypeConfiguration<FabricEntity>
{
    public void Configure(EntityTypeBuilder<FabricEntity> builder)
    {
        builder.ToTable("TB_TYPE");

        builder.Property(f => f.Type)
        .HasColumnName("TXT_TYPE")
        .IsRequired()
        .HasMaxLength(50);
    }
}
