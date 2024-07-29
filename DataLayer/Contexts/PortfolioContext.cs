using System;
using System.Collections.Generic;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Contexts;

public partial class PortfolioContext : DbContext
{
    public PortfolioContext()
    {
    }

    public PortfolioContext(DbContextOptions<PortfolioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Education> Education { get; set; }

    public virtual DbSet<Experience> Experience { get; set; }

    public virtual DbSet<ExperienceDetails> ExperienceDetails { get; set; }

    public virtual DbSet<Facts> Facts { get; set; }

    public virtual DbSet<ProjectPhotos> ProjectPhotos { get; set; }

    public virtual DbSet<ProjectTypes> ProjectTypes { get; set; }

    public virtual DbSet<Projects> Projects { get; set; }

    public virtual DbSet<Services> Services { get; set; }

    public virtual DbSet<Skills> Skills { get; set; }
    public virtual DbSet<Users> Users { get; set; }
    public virtual DbSet<Messages> Messages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=portfolio;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Educatio__3213E83FBB6C17C7");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Institution)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Experien__3214EC27B9C2A259");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompanyName).HasMaxLength(255);
            entity.Property(e => e.JobTitle).HasMaxLength(255);
            entity.Property(e => e.Location).HasMaxLength(255);
        });

        modelBuilder.Entity<ExperienceDetails>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Experien__3214EC2705229129");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExperienceId).HasColumnName("ExperienceID");

            entity.HasOne(d => d.Experience).WithMany(p => p.ExperienceDetails)
                .HasForeignKey(d => d.ExperienceId)
                .HasConstraintName("FK__Experienc__Exper__45F365D3");
        });

        modelBuilder.Entity<Facts>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Facts__3214EC27ACAA9941");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Fact)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.IconClass)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProjectPhotos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProjectP__3214EC275373AE04");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectPhotos)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__ProjectPh__Proje__4D94879B");
        });

        modelBuilder.Entity<ProjectTypes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProjectT__3214EC273222CA09");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Projects>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Projects__3214EC2771951F19");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProjectDate).HasColumnType("date");
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.TypeId).HasColumnName("TypeID");

            entity.HasOne(d => d.Type).WithMany(p => p.Projects)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK__Projects__TypeID__4AB81AF0");
        });

        modelBuilder.Entity<Services>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Services__3214EC278EA6850A");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Icon)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Skills>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3214EC27A69DA157");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Skill)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
