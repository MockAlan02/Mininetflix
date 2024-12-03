using System.Text.Json.Serialization;

namespace MiniNetflix.Core.Entities
{
    public class Serie : BaseEntity
    {
        public Serie()
        {
            GenreSeries = new HashSet<GenreSerie>();
        }
        public required string Name { get; set; }
        public required string ImageUrl { get; set; }
        public required string LinkVideo { get; set; }
        public int? ProductionId { get; set; }

        public virtual Production? Production { get; set; }
        [JsonIgnore]
        public virtual ICollection<GenreSerie> GenreSeries { get; set; }
    }
}


