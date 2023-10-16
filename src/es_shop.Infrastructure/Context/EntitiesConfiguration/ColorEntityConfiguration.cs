using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EsShop.Domain.Entities;

namespace EsShop.Infrastructure.Context.EntitiesConfiguration;

public class ColorEntityConfiguration : IEntityTypeConfiguration<ColorEntity>
{
    public void Configure(EntityTypeBuilder<ColorEntity> builder)
    {
        builder.ToTable("TB_COLOR");

        builder.Property(f => f.Color)
        .HasColumnName("TXT_COLOR")
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(f => f.Hex)
        .HasColumnName("TXT_HEX")
        .IsRequired()
        .HasMaxLength(7);


    }
}
