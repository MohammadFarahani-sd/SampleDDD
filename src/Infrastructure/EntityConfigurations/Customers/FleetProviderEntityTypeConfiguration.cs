using FleetProvider.Domain.AggregatesModel.FleetProviderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetProvider.Infrastructure.EntityConfigurations.Customers;

public class FleetShiftEntityTypeConfiguration : EntityTypeConfiguration<FleetShift>
{
    public override void ConfigureDerived(EntityTypeBuilder<FleetShift> configuration)
    {
        configuration.ToTable("FleetShift", "FP");

        configuration.Property(o => o.Id);

        configuration.HasKey(o => o.Id);
    }
}