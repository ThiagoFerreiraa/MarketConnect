using MarketConnect.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketConnect.ProductAPI.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    //Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Configurações para os campos da tabela Category
        #region Category
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);

            modelBuilder.Entity<Category>()
                     .Property(c => c.Name)
                         .HasMaxLength(100)
                              .IsRequired();

            modelBuilder.Entity<Category>()
                  .HasMany(c => c.Products)
                  .WithOne(c => c.Category)
                              .IsRequired()
          .OnDelete(DeleteBehavior.Cascade);
        #endregion

        //Configurações para os campos da tebela Product
        #region Product
        modelBuilder.Entity<Product>().HasKey(p => p.Id);

        modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                    .HasMaxLength(100)
                        .IsRequired();

        modelBuilder.Entity<Product>()
         .Property(p => p.Description)
                    .HasMaxLength(255)
                        .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(p => p.ImageURL)
                    .HasMaxLength(255)
                        .IsRequired();

        modelBuilder.Entity<Product>()
               .Property(p => p.Price)
                  .HasPrecision(12, 2);
        #endregion

    }
}
