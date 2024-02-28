namespace BaiTapApi.Helper
{
    public class PageResult<T>
    {
        public Pagination pagination { get; set; }
        public IEnumerable<T> items { get; set; }

        public PageResult() { }
        public PageResult(Pagination pagination, IEnumerable<T> items)
        {
            this.pagination = pagination;
            this.items = items;
        }
        public static IQueryable<T> ToPagedResult(Pagination pagination, IQueryable<T> items)
        {
            pagination.PageNumber = pagination.PageNumber < 1 ? 1 : pagination.PageNumber;
            if (pagination.PageNumber > 0)
            {
                items = items.Skip(pagination.PageSize * (pagination.PageNumber - 1)).Take(pagination.PageSize);

            }
            return items;

        }
    }
}
