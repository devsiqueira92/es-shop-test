using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EsShop.Domain.Entities;

namespace EsShop.Infrastructure.Context.EntitiesConfiguration;

public class ShirtEntityConfiguration : IEntityTypeConfiguration<ShirtEntity>
{
    public void Configure(EntityTypeBuilder<ShirtEntity> builder)
    {
        builder.ToTable("TB_SHIRT");

		builder.Property(f => f.Name)
		.HasColumnName("TXT_NAME")
		.IsRequired()
		.HasMaxLength(20);
	}
}
