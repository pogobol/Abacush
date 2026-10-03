namespace Abacush.Domain.Entities
{
    public class QualifiedObject : BaseEntity
    {
        public ObjectType Type { get; set; }
        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
    }
}
