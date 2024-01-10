using System.ComponentModel.DataAnnotations.Schema;
using FleetProvider.Domain.SeedWork;

namespace FleetProvider.Domain.AggregatesModel.FleetProviderAggregate;

[Table("FleetShift", Schema = "FP")]
public class FleetShift : Entity
{
    public int FleetId { get; private set; }
    [ForeignKey(nameof(FleetId))]
    public virtual Fleet Fleet { get; set; }

    public int FleetProviderId { get; private set; }
    
    [ForeignKey(nameof(FleetProviderId))]
    public virtual FleetProvider FleetProvider { get; set; }

    public bool Active { get;private set; }
    
    protected FleetShift()
    {
    }

    public FleetShift(int fleetId, int fleetProviderId)
    {
        FleetId = fleetId;
        FleetProviderId = fleetProviderId;
        Active = true;
    }

    public void InactiveFleet()
    {
        Active = false;
    }
    /// <summary>
    /// we need some business rule for active fleet which is inactivated before
    /// </summary>
    public void ActiveFleet()
    {

    } 
}