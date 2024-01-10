namespace FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.RoleValidations;

public interface IShiftDayUniquenessChecker
{
    Task<bool> Exists(int shift, DateTime date);
}