using FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.RoleValidations;
using FleetProvider.Domain.SeedWork;

namespace FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.Rules.Shifts;

public class IsExistThisShiftRule : IBusinessRule
{
    private readonly IShiftDayUniquenessChecker _checker;
    private readonly int _shiftId;
    private readonly DateTime _date;
    public IsExistThisShiftRule(IShiftDayUniquenessChecker checker, int shiftId, DateTime date)
    {
        _checker = checker;
        _shiftId = shiftId;
        _date = date;
    }

    public Task<bool> IsBroken() => _checker.Exists(_shiftId, _date);

    public string Message => $"fleet provider with this information is not valid.";

    public string[] Properties => new[] { nameof(FleetProvider.Date) };

    public string ErrorType => BusinessRuleType.Uniqueness.ToString("G");
}