namespace FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.RoleValidations;

public interface IsNotExistThisShiftChecker
{
    Task<bool> Exists(int shift);
}