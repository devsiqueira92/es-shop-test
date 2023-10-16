using Microsoft.EntityFrameworkCore;
using EsShop.Domain.Entities;
using EsShop.Infrastructure.Context.EntitiesConfiguration;

namespace EsShop.Infrastructure.Context;

public sealed class EsShopContext : DbContext
{
    public DbSet<ColorEntity> Colors { get; set; }
    public DbSet<FabricEntity> Fabrics { get; set; }
	public DbSet<ShirtEntity> Shirts { get; set; }
	public DbSet<ShirtSpecificationImageEntity> ShirtSpecificationImage { get; set; }

	public DbSet<ShirtSpecificationEntity> ShirtSpecifications { get; set; }


	public EsShopContext(DbContextOptions<EsShopContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // This is already configured on the Startup.cs
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new ColorEntityConfiguration().Configure(modelBuilder.Entity<ColorEntity>());
        new FabricEntityConfiguration().Configure(modelBuilder.Entity<FabricEntity>());
        new ShirtEntityConfiguration().Configure(modelBuilder.Entity<ShirtEntity>());
		new ShirtSpecificationEntityConfiguration().Configure(modelBuilder.Entity<ShirtSpecificationEntity>());
		new ShirtSpecificationImageEntityConfiguration().Configure(modelBuilder.Entity<ShirtSpecificationImageEntity>());
	}
}
