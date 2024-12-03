

namespace MiniNetflix.Core.Helper.Pagination
{
    public class Filtered
    {
        public string? Name { get; set; } = "";
        public int[]? Genre { get; set; } = null;
        public int? Production { get; set; } = 0;

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
       
    }
}
