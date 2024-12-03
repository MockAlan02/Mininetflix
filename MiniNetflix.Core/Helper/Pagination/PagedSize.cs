

namespace MiniNetflix.Core.Helper.Pagination
{
    public class PagedList<T>
    {
        private PagedList(List<T> items, int page, int pageSize, int totalCount)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

      public List<T> Items { get; set; }

      public int Page {  get; set; }

      public int PageSize { get; set; }

      public int TotalCount { get; set; }

      public bool HasNextPage => Page * PageSize < TotalCount;

      public bool HasPreviousPage => Page > 1;

        public static PagedList<T> Create(IEnumerable<T> query, int page, int pageSize)
        {
            var totalCount = query.Count();
            var items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new(items, page, pageSize, totalCount);
        }
    }
}
