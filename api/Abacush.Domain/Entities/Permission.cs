namespace Abacush.Domain.Entities
{
    public class Permission
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ObjectId { get; set; }
        public required QualifiedObject Object { get; set; }
        public List<QualifiedSubject> Subjects { get; set; } = new List<QualifiedSubject>();
        public List<string> Actions { get; set; } = new List<string>();
    }
}
