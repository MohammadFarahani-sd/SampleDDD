using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using FleetProvider.Domain.Exceptions;
using FleetProvider.Domain.SeedWork;

namespace FleetProvider.Domain.AggregatesModel.FleetProviderAggregate;

[Table("Fleet", Schema = "FP")]
public class Fleet : Entity
{
    [Required]
    [MaxLength(256)]
    [MinLength(3)]
    public string Name { get; private set; } = null!;
    protected Fleet()
    {
    }

    public Fleet(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new DomainException("Invalid name");
        }
        this.Name = name;
    }
}