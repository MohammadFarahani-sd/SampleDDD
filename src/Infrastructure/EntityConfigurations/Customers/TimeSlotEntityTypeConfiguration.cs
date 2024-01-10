using FleetProvider.Domain.AggregatesModel.FleetProviderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetProvider.Infrastructure.EntityConfigurations.Customers;

public class TimeSlotEntityTypeConfiguration : EntityTypeConfiguration<TimeSlot>
{
    public override void ConfigureDerived(EntityTypeBuilder<TimeSlot> configuration)
    {
        configuration.ToTable("TimeSlot", "FP");

        configuration.Property(o => o.Id);

        configuration.HasKey(o => o.Id);
    }
}