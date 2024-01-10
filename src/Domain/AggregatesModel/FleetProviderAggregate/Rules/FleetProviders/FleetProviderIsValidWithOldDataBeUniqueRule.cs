using FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.RoleValidations;
using FleetProvider.Domain.SeedWork;

namespace FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.Rules.FleetProviders;
public class FleetProviderIsValidWithOldDataBeUniqueRule : IBusinessRule
{
    private readonly IFleetProviderValidationChecker _checker;
    private readonly int _shiftId;
    private readonly DateTime _date;
    private readonly int _fleetId;
    public FleetProviderIsValidWithOldDataBeUniqueRule(IFleetProviderValidationChecker checker, int shiftId, DateTime date, int fleetId)
    {
        _checker = checker;
        _shiftId = shiftId;
        _date = date;
        _fleetId = fleetId;
    }

    public Task<bool> IsBroken() => _checker.Exists(_shiftId, _date, _fleetId);

    public string Message => $"fleet provider with this information is not valid.";

    public string[] Properties => new[] { nameof(FleetProvider.Date) };

    public string ErrorType => BusinessRuleType.Uniqueness.ToString("G");
}
