namespace FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.RoleValidations;

public interface IFleetShouldBeFreeChecker
{
    Task<bool> IsFleetFree(int shift, DateTime date, int fleetId);
}