using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Models;

public partial class HRMSDbContext : DbContext
{
    public HRMSDbContext()
    {
    }

    public HRMSDbContext(DbContextOptions<HRMSDbContext> options)
        : base(options)
    {
    }

   public  DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    public DbSet<Designation> Designations { get; set; }

    public DbSet<Shift> Shifts { get; set; }

    public DbSet<Attendance> Attendances { get; set; } 
    public DbSet<Holiday> Holidays { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-41O9E62;Database=HRMS;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Holiday>(entity =>
        {
            entity.HasKey(e => e.HolidayId).HasName("PK__Holidays__2D35D57A7A09319E");

            entity.Property(e => e.HolidayName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
