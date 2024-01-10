namespace FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.RoleValidations;

public interface IShiftValidationChecker
{
    Task<bool> Validation(int polygonId, int timeSlotId);
}