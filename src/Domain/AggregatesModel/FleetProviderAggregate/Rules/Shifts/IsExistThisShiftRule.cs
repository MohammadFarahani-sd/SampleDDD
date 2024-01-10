using FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.RoleValidations;
using FleetProvider.Domain.SeedWork;

namespace FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.Rules.Shifts;

public class IsExistThisShiftRule : IBusinessRule
{
    private readonly IsNotExistThisShiftChecker _checker;
    private readonly int _shiftId;
    public IsExistThisShiftRule(IsNotExistThisShiftChecker checker, int shiftId)
    {
        _checker = checker;
        _shiftId = shiftId;
    }

    public Task<bool> IsBroken() => _checker.Exists(_shiftId);

    public string Message => $"fleet provider with this information is not valid.";

    public string[] Properties => new[] { nameof(FleetProvider.Date) };

    public string ErrorType => BusinessRuleType.Uniqueness.ToString("G");
}