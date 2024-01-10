using System.ComponentModel.DataAnnotations.Schema;
using FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.RoleValidations;
using FleetProvider.Domain.AggregatesModel.FleetProviderAggregate.Rules.Shifts;
using FleetProvider.Domain.Exceptions;
using FleetProvider.Domain.SeedWork;

namespace FleetProvider.Domain.AggregatesModel.FleetProviderAggregate;

[Table("Shift", Schema = "FT")]
public class Shift : Entity
{
    public int TimeSlotId { get; private set; }

    public int Polygon { get; private set; }

    public bool Active { get; private set; }

    protected Shift()
    {
    }


    private Shift(int polygon, int timeSlotId)
    {
        if (polygon < 1)
            throw new DomainException("invalid polygon id");

        Polygon = polygon;
        TimeSlotId = timeSlotId;
        Active = true;

    }

    public static async Task<Shift> Create(int polygon, int timeSlotId, IShiftValidationChecker checker)
    {
        //find overlapping of time when we want to detect time to create a slot
        await CheckRule(new PolygonWithTimeSlotBeUniqueRule(checker, polygon, timeSlotId));

        return new Shift(polygon, timeSlotId);

    }

    public void InactiveShift()
    {
        Active = false;
    }

    public async Task ActiveShift(IShiftValidationChecker checker)
    {
        await CheckRule(new PolygonWithTimeSlotBeUniqueRule(checker, Polygon, TimeSlotId));

        Active = true;
    }
}