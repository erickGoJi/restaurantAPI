using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using restaurant_api.Domain;

namespace restaurant_api.Infrastructure.Persistence
{
    public partial class restaurant_dbContext : DbContext
    {
        public virtual DbSet<Cat_Role> Cat_Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public restaurant_dbContext()
        {
        }

        public restaurant_dbContext(DbContextOptions<restaurant_dbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat_Role>(entity =>
            {
                entity.ToTable("Cat_Role");

                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.role_name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.last_name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.salary).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.second_last_name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.role_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Cat_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
