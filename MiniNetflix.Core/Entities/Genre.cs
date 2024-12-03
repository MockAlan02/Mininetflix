

using System.Text.Json.Serialization;

namespace MiniNetflix.Core.Entities
{
    public class Genre : BaseEntity
    {
        public required string Name { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<GenreSerie>? GenreSeries { get; set; } = null;
    }
}
