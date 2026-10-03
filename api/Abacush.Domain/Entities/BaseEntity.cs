namespace Abacush.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; init; }
        public string? Description { get; set; }
    }
}
