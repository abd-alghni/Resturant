using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Resturants.API.Models
{
    public partial class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext()
        {
        }

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Meal> Meals { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Resturant> Resturants { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=RestaurantDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address).HasDefaultValueSql("(N'')");

                entity.Property(e => e.PhoneNumber).HasDefaultValueSql("(N'')");
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_Meals_CategoryId");

                entity.HasIndex(e => e.ResturantId, "IX_Meals_ResturantId");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Resturant)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.ResturantId);

                entity.HasMany(d => d.Orders)
                    .WithMany(p => p.Meals)
                    .UsingEntity<Dictionary<string, object>>(
                        "MealOrder",
                        l => l.HasOne<Order>().WithMany().HasForeignKey("OrdersId").OnDelete(DeleteBehavior.ClientSetNull),
                        r => r.HasOne<Meal>().WithMany().HasForeignKey("MealsId"),
                        j =>
                        {
                            j.HasKey("MealsId", "OrdersId");

                            j.ToTable("MealOrder");

                            j.HasIndex(new[] { "OrdersId" }, "IX_MealOrder_OrdersId");
                        });
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerId1, "IX_Orders_CustomerId1");

                entity.HasIndex(e => e.ResturantId, "IX_Orders_ResturantId");

                entity.HasOne(d => d.CustomerId1Navigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId1);

                entity.HasOne(d => d.Resturant)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ResturantId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
