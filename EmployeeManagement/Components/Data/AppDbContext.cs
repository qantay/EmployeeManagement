using EmployeeManagement.Components.Models;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Components.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Attendance>  attendance { get; set; }
    public DbSet<Employee>  employees { get; set; }
    public DbSet<Department>  departments { get; set; }
    public DbSet<Position>  positions { get; set; }
    public DbSet<Salary> salaries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.ToTable("Attendance");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.WorkDate).HasColumnName("work_date");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.EmId).HasColumnName("em_id");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("employees");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FullName).HasColumnName("full_name");
            entity.Property(e => e.DOB).HasColumnName("dob");
            entity.Property(e => e.Gender).HasColumnName("Gender");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Place).HasColumnName("place");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.DepartId).HasColumnName("depart_id");
            entity.Property(e => e.PosId).HasColumnName("pos_id");

            entity.HasMany(e => e.Attendances)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Salaries)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("departments");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartName).HasColumnName("depart_name");
    
            entity.HasMany(e => e.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        modelBuilder.Entity<Position>(entity =>
        {
            entity.ToTable("positions");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PosName).HasColumnName("pos_name");
            entity.Property(e => e.BaseSalary).HasColumnName("base_salary");
     
            entity.HasMany(e => e.Employees)
                .WithOne(e => e.Position)
                .HasForeignKey(e => e.PosId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.ToTable("salaries");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BaseSalary).HasColumnName("base_salary");
            entity.Property(e => e.Allowance).HasColumnName("allowance");
            entity.Property(e => e.Bonus).HasColumnName("bonus");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.PayMonth).HasColumnName("pay_month");
            entity.Property(e => e.EmId).HasColumnName("em_id");
        });
    }
}