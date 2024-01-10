using FleetProvider.Domain.AggregatesModel.FleetProviderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetProvider.Infrastructure.EntityConfigurations.Customers;

public class ShiftEntityTypeConfiguration : EntityTypeConfiguration<Shift>
{
    public override void ConfigureDerived(EntityTypeBuilder<Shift> configuration)
    {
        configuration.ToTable("Shift", "FP");

        configuration.Property(o => o.Id);

        configuration.HasKey(o => o.Id);
    }
}