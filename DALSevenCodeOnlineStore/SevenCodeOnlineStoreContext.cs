

using System;
using System.IO;
using DALSevenCodeOnlineStore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DALSevenCodeOnlineStore
{
    public partial class SevenCodeOnlineStoreContext : IdentityDbContext<ApplicationUser>
    {
        public SevenCodeOnlineStoreContext()
        {
        }

        public SevenCodeOnlineStoreContext(DbContextOptions<SevenCodeOnlineStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<ProductTypes> ProductTypes { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<SpecialTags> SpecialTags { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //20.4   // https://stackoverflow.com/questions/40703615/the-entity-type-identityuserloginstring-requires-a-primary-key-to-be-defined

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.NameArabic).HasMaxLength(150);

                entity.Property(e => e.NameEnglish).HasMaxLength(150);

                entity.Property(e => e.PageUrl).HasColumnName("PageURL");

                entity.Property(e => e.ParentCategoryId).HasColumnName("ParentCategoryID");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasIndex(e => e.OrderId);

                entity.HasIndex(e => e.PorductId);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Porduct)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.PorductId);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.PhoneNo).IsRequired();
            });

            modelBuilder.Entity<ProductTypes>(entity =>
            {
                entity.Property(e => e.ProductType).IsRequired();
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasIndex(e => e.ProductTypeId);

                entity.HasIndex(e => e.SpecialTagId);

                entity.Property(e => e.Name).IsRequired();


                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_Category");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.ProductTypes)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId);

                entity.HasOne(d => d.SpecialTags)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SpecialTagId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                // optionsBuilder.UseSqlServer("Data Source=db\\MSSQL14,1444;Initial Catalog=db;User ID=sa;Password=E-14");
                
                IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
                var connectionString = configuration.GetConnectionString("SevenCodeOnlineStoreConnectionString");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}