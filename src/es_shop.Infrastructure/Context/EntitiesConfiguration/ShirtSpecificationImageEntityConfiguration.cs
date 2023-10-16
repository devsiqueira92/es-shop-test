using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EsShop.Domain.Entities;

namespace EsShop.Infrastructure.Context.EntitiesConfiguration;

public class ShirtSpecificationImageEntityConfiguration : IEntityTypeConfiguration<ShirtSpecificationImageEntity>
{
    public void Configure(EntityTypeBuilder<ShirtSpecificationImageEntity> builder)
    {
        builder.ToTable("TB_SHIRT_SPECIFICATION_IMAGES");

		builder.Property(f => f.ShirtSpecificationId)
		.HasColumnName("COD_SHIRT_SPECIFICATION")
		.IsRequired();

		builder.HasOne(p => p.ShirtSpecification)
		.WithMany()
		.HasForeignKey(p => p.ShirtSpecificationId)
		.OnDelete(DeleteBehavior.NoAction);

		builder.Property(f => f.ImageId)
        .HasColumnName("COD_IMAGE")
        .IsRequired();
    }
}
