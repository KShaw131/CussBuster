using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CussBuster.Database.Entities;

namespace CussBuster.Database.Context
{
    public partial class CussBusterContext : DbContext
    {
        public CussBusterContext()
        {
        }

        public CussBusterContext(DbContextOptions<CussBusterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CurseWords> CurseWords { get; set; }
        public virtual DbSet<WordType> WordType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;User Id=sa;Password=Levvel1!;Database=master");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurseWords>(entity =>
            {
                entity.ToTable("curseWords");

                entity.Property(e => e.CurseWord)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.CurseWords)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK__curseWord__TypeI__15702A09");
            });

            modelBuilder.Entity<WordType>(entity =>
            {
                entity.ToTable("wordType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
