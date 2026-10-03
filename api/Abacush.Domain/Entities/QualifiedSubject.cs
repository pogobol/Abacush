namespace Abacush.Domain.Entities
{
    public class QualifiedSubject : BaseEntity
    {
        public string Interface { get; set; }
        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
    }
}
