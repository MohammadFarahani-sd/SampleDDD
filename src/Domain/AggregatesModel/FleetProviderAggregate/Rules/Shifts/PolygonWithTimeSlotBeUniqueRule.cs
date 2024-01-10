using FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.RoleValidations;
using FleetProvider.Domain.SeedWork;

namespace FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.Rules.Shifts;
public class PolygonWithTimeSlotBeUniqueRule : IBusinessRule
{
    private readonly IShiftValidationChecker _checker;
    private readonly int _polygonId;
    private readonly int _timeSlotId;
    public PolygonWithTimeSlotBeUniqueRule(IShiftValidationChecker checker, int polygon, int timeSlotId)
    {
        _checker = checker;
        _polygonId = polygon;
        _timeSlotId = timeSlotId;
    }

    public Task<bool> IsBroken() => _checker.Validation(_polygonId,_timeSlotId);

    public string Message => $"shift with this information is not valid.";

    public string[] Properties => new[] { nameof(Shift.Id) };

    public string ErrorType => BusinessRuleType.Uniqueness.ToString("G");
}
