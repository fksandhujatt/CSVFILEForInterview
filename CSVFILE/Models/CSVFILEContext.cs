using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CSVFILE.Models
{
    public partial class CSVFILEContext : DbContext
    {
        public CSVFILEContext()
        {
        }

        public CSVFILEContext(DbContextOptions<CSVFILEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Stock> Stock { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-H84BB4Q;Database=CSVFILE;User Id=sa; Password=taxi9211;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Stock__B40CC6CDA3A2E56B");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Product)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
