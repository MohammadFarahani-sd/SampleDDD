using System.ComponentModel.DataAnnotations.Schema;
using FleetProvider.Domain.Exceptions;
using FleetProvider.Domain.SeedWork;

namespace FleetProvider.Domain.AggregatesModel.FleetProviderAggregate;

[Table("TimeSlot", Schema = "FP")]
public class TimeSlot : Entity
{
    [Column("From", TypeName = "time")]
    public TimeOnly From { get; private set; }

    [Column("To", TypeName = "time")] 
    public TimeOnly To { get; private set; }

    public TimeSlot()
    {

    }

    public TimeSlot(TimeOnly from, TimeOnly to, int configOfSlotPeriod)
    {
        if (from >= to)
            throw new DomainException("time slot is not valid");

        //this times means of the period between start time and end time 
        if (from.AddMinutes(configOfSlotPeriod) > to)
            throw new DomainException("invalid shift times");

        From = from;
        To = to;
    }
}
