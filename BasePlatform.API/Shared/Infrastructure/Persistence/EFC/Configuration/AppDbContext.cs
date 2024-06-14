using BasePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using Policy = BasePlatform.API.Insurance.Domain.Model.Aggregates.Policy;

namespace BasePlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Policy>().HasKey(c => c.Id);
        builder.Entity<Policy>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Policy>().Property(c => c.Costumer).IsRequired();
        builder.Entity<Policy>().Property(c => c.ProductId).IsRequired().HasConversion<int>(); ;
        builder.Entity<Policy>().Property(c => c.Address).IsRequired();
        builder.Entity<Policy>().Property(c => c.Dni).IsRequired();
        builder.Entity<Policy>().Property(c => c.Age).IsRequired();

        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}