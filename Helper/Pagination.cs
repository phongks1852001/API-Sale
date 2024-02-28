namespace BaiTapApi.Helper
{
    public class Pagination
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int totalCount { get; set; }
        public int totalPage
        {
            get
            {
                if (this.PageSize == 0) return 0;
                var total = this.totalCount / this.PageSize;
                if (this.totalCount % this.PageSize != 0) total += 1;
                return total;
            }
        }
        public Pagination()
        {
            PageNumber = 1;
            PageSize = -1;

        }

    }
}
