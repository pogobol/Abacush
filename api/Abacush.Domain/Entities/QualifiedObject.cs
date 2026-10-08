namespace Abacush.Domain.Entities
{
    public class QualifiedObject : BaseEntity
    {
        public Guid TypeId { get; set; }
        public QualifiedType Type { get; set; }
        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
    }
}
