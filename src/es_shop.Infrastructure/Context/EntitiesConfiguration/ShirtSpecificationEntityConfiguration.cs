using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EsShop.Domain.Entities;

namespace EsShop.Infrastructure.Context.EntitiesConfiguration;

public class ShirtSpecificationEntityConfiguration : IEntityTypeConfiguration<ShirtSpecificationEntity>
{
    public void Configure(EntityTypeBuilder<ShirtSpecificationEntity> builder)
    {
        builder.ToTable("TB_SHIRT_SPECIFICATION");

		builder.Property(f => f.ShirtId)
		.HasColumnName("COD_SHIRT")
		.IsRequired();

		builder.HasOne(p => p.ShirtEntity)
		.WithMany()
		.HasForeignKey(p => p.ShirtId)
		.OnDelete(DeleteBehavior.NoAction);

		builder.Property(f => f.ColorId)
        .HasColumnName("COD_COLOR")
        .IsRequired();

        builder.HasOne(p => p.ColorEntity)
        .WithMany()
        .HasForeignKey(p => p.ColorId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.Property(f => f.FabricId)
        .HasColumnName("COD_FABRIC")
        .IsRequired();

        builder.HasOne(p => p.FabricEntity)
        .WithMany()
        .HasForeignKey(p => p.FabricId)
        .OnDelete(DeleteBehavior.NoAction);
    }
}
