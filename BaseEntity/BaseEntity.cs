using System.ComponentModel.DataAnnotations;

namespace dotnet.helper.Entity;

public abstract class BaseEntity<T>
{
    [Key]
    public T Id { get; set; } = default!;
    public bool IsActive { get; set; } = false;
    public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTime.UtcNow;
}