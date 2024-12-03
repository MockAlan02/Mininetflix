namespace MiniNetflix.Core.Entities
{
    public class Production : BaseEntity
    {
        public required string Name { get; set; }

        public virtual ICollection<Serie>? Serie { get; set; } = null;
    }
}
