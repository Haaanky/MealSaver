using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MealSaver.Models.Entities
{
    public partial class FoodObjContext : DbContext
    {
        public FoodObjContext()
        {
        }

        public FoodObjContext(DbContextOptions<FoodObjContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactForm> ContactForm { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<ContactForm>(entity =>
            {
                entity.ToTable("ContactForm", "FoodObj");

                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Name).HasMaxLength(64);

                entity.Property(e => e.Question).IsRequired();
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("Products", "FoodObj");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.UnitOfMeasurement)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(450);
            });
        }
    }
}
