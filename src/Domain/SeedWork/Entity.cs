using System.ComponentModel.DataAnnotations;

namespace FleetProvider.Domain.SeedWork;
[Serializable]
public abstract class Entity
{
    [Key]
    public int Id { get; protected set; }
    public bool IsDeleted { get; protected set; } = false;

    public DateTimeOffset? ModifiedAt { get; protected set; }

    public DateTimeOffset CreatedAt { get; protected set; }

    protected static async Task CheckRule(IBusinessRule rule)
    {
        if (await rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule, rule.Properties, rule.ErrorType);
        }
    }
}
