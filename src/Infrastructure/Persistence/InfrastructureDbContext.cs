using FleetProvider.Domain.SeedWork;
using FleetProvider.Infrastructure.EntityConfigurations.Customers;
using Microsoft.EntityFrameworkCore;

namespace FleetProvider.Infrastructure.Persistence;

public class InfrastructureDbContext : DbContext,  IUnitOfWork
{
    public InfrastructureDbContext(DbContextOptions<InfrastructureDbContext> options) : base(options)
    {
    }

    protected InfrastructureDbContext(DbContextOptions options) : base(options)
    {
    }


    
    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await base.SaveChangesAsync(cancellationToken);

        return true;
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TimeSlotEntityTypeConfiguration());

    }
}
