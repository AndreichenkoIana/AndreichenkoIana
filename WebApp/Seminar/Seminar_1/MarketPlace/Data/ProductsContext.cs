using MarketPlace.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Data
{
    public partial class ProductsContext : DbContext
    {
        public DbSet<ProductGroup> ProductGroups { get; set; }

        public DbSet<Product> Procucts { get; set; }

        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

            => optionsBuilder.UseSqlServer("Data Source= NB-Z4-PF3BPTC1\\SQLEXPRESS; Initial Catalog= MarketPlace; Trusted_Connection=True; TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("productgroup_pkey");

                entity.ToTable("productgroups");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Description).HasColumnName("description");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("product_pkey");

                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.Description)
                    .HasMaxLength(1024)
                    .HasColumnName("description");
                entity.Property(e => e.Price)
    .           HasMaxLength(1024)
    .           HasColumnName("price");

                entity.HasOne(e => e.ProductGroup).WithMany(p => p.Products);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("store_pkey");

                entity.ToTable("stores");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(e => e.Product).WithMany(p => p.Stores);

            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
