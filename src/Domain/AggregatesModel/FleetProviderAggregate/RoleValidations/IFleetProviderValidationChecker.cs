namespace FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.RoleValidations;

public interface IFleetProviderValidationChecker
{
    Task<bool> Exists(int shift, DateTime date, int fleetId);
}