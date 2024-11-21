using System.Data;

namespace Plurish.Auth.Domain.Entities;
public class EntityBase
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime CreatedOn { get; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
}

