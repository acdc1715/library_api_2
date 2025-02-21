namespace LibraryAPI.Models.QueryParameters
{
    public class QueryParameters
    {
        public string? SearchQuery { get; set; }
        public Guid? AuthorID { get; set; }
        public string? SortBy { get; set; }
        //public bool IsAscending { get; set; } = true;

        private int _pageNumber = 1;
        private int _pageSize = 10;
        private const int MaxPageSize = 100;

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = value < 1 ? 1 : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }

}
