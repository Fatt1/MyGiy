using Microsoft.EntityFrameworkCore;

namespace Demo.Contract.Abstractions.Shared
{
    public class PagedResult<T>
    {
        public const int UpperPageSize = 100;
        public const int DefaultPageSize = 10;
        public const int DefaultPageIndex = 1;


        public PagedResult(List<T> items, int pageIndex, int pageSize, int totalCount)
        {
            Items = items;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public List<T> Items { get; }
        public int PageIndex { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<PagedResult<T>> CreateAsync(IQueryable<T> query, int pageIndex, int pageSize)
        {
            pageIndex = pageIndex < 1 ? DefaultPageIndex : pageIndex;
            pageSize = pageSize < 1
                ? DefaultPageSize
                : pageSize > UpperPageSize
                ? UpperPageSize
                : pageSize;
            var totalCount = await query.CountAsync();
            var items = await query
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
            return new PagedResult<T>(items, pageIndex, pageSize, totalCount);
        }
    }
}
