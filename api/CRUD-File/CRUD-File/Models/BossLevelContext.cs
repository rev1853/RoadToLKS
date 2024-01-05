using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD_File.Models;

public partial class BossLevelContext : DbContext
{
    public BossLevelContext()
    {
    }

    public BossLevelContext(DbContextOptions<BossLevelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CrudImage> CrudImages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=boss_level;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CrudImage>(entity =>
        {
            entity.ToTable("crud_image");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImagePath).HasColumnType("ntext");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
