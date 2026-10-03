namespace Abacush.Domain.Entities
{
    public class Permission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required QualifiedObject Object { get; init; }
        public List<QualifiedSubject> Subjects { get; set; } = new List<QualifiedSubject>();
        public List<string> Actions { get; set; } = new List<string>();
    }
}
