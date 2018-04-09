using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ActionBook.Models
{
    public partial class MasterContext : DbContext
    {
        public virtual DbSet<ActionBooks> ActionBooks { get; set; }
        public virtual DbSet<ActionLists> ActionLists { get; set; }

        public MasterContext(DbContextOptions<MasterContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionBooks>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<ActionLists>(entity =>
            {
                entity.Property(e => e.Image1).IsRequired();

                entity.Property(e => e.Image2).IsRequired();

                entity.Property(e => e.Image3).IsRequired();

                entity.Property(e => e.Image4).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Text1).IsRequired();

                entity.Property(e => e.Text2).IsRequired();

                entity.Property(e => e.Text3).IsRequired();

                entity.Property(e => e.Text4).IsRequired();

                entity.HasOne(d => d.ActionBook)
                    .WithMany(p => p.ActionLists)
                    .HasForeignKey(d => d.ActionBookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionLists_ActionBooks");

                entity.HasOne(d => d.Choise1Navigation)
                    .WithMany(p => p.InverseChoise1Navigation)
                    .HasForeignKey(d => d.Choise1)
                    .HasConstraintName("FK_ActionLists_ActionListChoise1");

                entity.HasOne(d => d.Choise2Navigation)
                    .WithMany(p => p.InverseChoise2Navigation)
                    .HasForeignKey(d => d.Choise2)
                    .HasConstraintName("FK_ActionLists_ActionListChoise2");

                entity.HasOne(d => d.Choise3Navigation)
                    .WithMany(p => p.InverseChoise3Navigation)
                    .HasForeignKey(d => d.Choise3)
                    .HasConstraintName("FK_ActionLists_ActionListChoise3");

                entity.HasOne(d => d.Choise4Navigation)
                    .WithMany(p => p.InverseChoise4Navigation)
                    .HasForeignKey(d => d.Choise4)
                    .HasConstraintName("FK_ActionLists_ActionListChoise4");
            });
        }
    }
}
