using System.ComponentModel.DataAnnotations.Schema;
using FleetProvider.Domain.SeedWork;

namespace FleetProvider.Domain.AggregatesModel.FleetProviderAggregate;

[Table("FleetShift", Schema = "FP")]
public class FleetShift : Entity
{
    public int FleetId { get; private set; }

    public int FleetProviderId { get; private set; }
    protected FleetShift()
    {
    }

    public FleetShift(int fleetId, int fleetProviderId)
    {
        FleetId = fleetId;
        FleetProviderId = fleetProviderId;
    }
}