using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetProvider.Infrastructure.EntityConfigurations.Customers;

public class FleetProviderEntityTypeConfiguration : EntityTypeConfiguration<Domain.AggregatesModel.FleetProviderAggregate.FleetProvider>
{
    public override void ConfigureDerived(EntityTypeBuilder<Domain.AggregatesModel.FleetProviderAggregate.FleetProvider> configuration)
    {
        configuration.ToTable("FleetProvider", "FP");

        configuration.Property(o => o.Id);

        configuration.HasKey(o => o.Id);

        var fleetShiftNavigation =
            configuration.Metadata.FindNavigation(nameof(Domain.AggregatesModel.FleetProviderAggregate.FleetProvider.FleetShifts));

        fleetShiftNavigation!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}