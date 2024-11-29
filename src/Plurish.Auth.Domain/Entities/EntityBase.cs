using System.ComponentModel.DataAnnotations;

namespace Plurish.Auth.Domain.Entities;
public class EntityBase
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime CreatedOn { get; } = DateTime.UtcNow;
    public bool IsActive { get; private set; } = true;

    public void Desactive()
    {
        IsActive = false;
    }
}

