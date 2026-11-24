// This is how the FinanceTracker application communicates with the database (eg. read, change data)

using FinanceTracker.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Api.Data;

public class FinanceTrackerDbContext : DbContext
{
    public FinanceTrackerDbContext(DbContextOptions<FinanceTrackerDbContext> options) : base(options) 
    {
    }

    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .Property(category => category.UserId)
            .HasMaxLength(128);

        modelBuilder.Entity<Category>()
            .Property(category => category.Name)
            .HasMaxLength(100);

        modelBuilder.Entity<Category>()
            .Property<string>("NormalizedName")
            .HasMaxLength(100)
            .HasComputedColumnSql(
                "UPPER(LTRIM(RTRIM([Name])) COLLATE Latin1_General_100_CI_AS_SC)",
                stored: true)
            .IsRequired();
        
        modelBuilder.Entity<Category>()
            .HasIndex("UserId", "NormalizedName", "Type")
            .IsUnique();
    }
}