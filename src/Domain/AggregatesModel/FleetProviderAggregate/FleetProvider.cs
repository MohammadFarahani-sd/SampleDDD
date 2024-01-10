using System.ComponentModel.DataAnnotations.Schema;
using FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.RoleValidations;
using FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.Rules.FleetProviders;
using FleetProvider.Domain.Exceptions;
using FleetProvider.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace FleetProvider.Domain.AggregatesModel.FleetProviderAggregate;

[Table("FleetProvider", Schema = "FT")]
public class FleetProvider : Entity, IAggregateRoot
{
    public int ShiftId { get; private set; }

    [NotMapped]
    [ForeignKey(nameof(ShiftId))]
    public virtual Shift Shift { get; set; }

    public int Capacity { get; private set; }

    /// <summary>
    /// this is a date only property , may be it is hard to create a migration for this 
    /// </summary>
    public DateTime Date { get; private set; }

    private readonly List<FleetShift> _fleetShifts;

    [BackingField(nameof(_fleetShifts))]
    public virtual IReadOnlyCollection<FleetShift> FleetShifts => _fleetShifts;

    public string? Description { get; private set; }

    protected FleetProvider()
    {
        _fleetShifts = new List<FleetShift>();
    }

    private FleetProvider(int shiftId, int capacity, DateTime date)
    {
        ShiftId = shiftId;
        Capacity = capacity;
        Date = date.Date;
        Description = $"shift created for {date.DayOfWeek} ";
    }


    public static async Task<FleetProvider> Create(int shiftId, int capacity, DateTime date,  IShiftDayUniquenessChecker checker)
    {
        
        await CheckRule(new ShiftFleetBeUniqueRule(checker, shiftId, date));

        return new FleetProvider(shiftId,capacity, date);
    }

    public async Task AddFleet(int fleetId, IFleetProviderValidationChecker checker)
    {
        await CheckRule(new FleetProviderIsValidWithOldDataBeUniqueRule(checker, ShiftId, Date, fleetId));



    }
}