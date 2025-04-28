using System;
using System.Collections.Generic;
using Homework_SkillTree.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace Homework_SkillTree.Data;

public partial class SkillTreeContext : DbContext
{
    public SkillTreeContext()
    {
    }

    public SkillTreeContext(DbContextOptions<SkillTreeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Homework1> Homework1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SkillTree;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Homework1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Homework__3214EC073C4C6C6C");

            entity.ToTable("Homework1");

            entity.Property(e => e.Category)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("category");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Money).HasColumnType("decimal(10, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
