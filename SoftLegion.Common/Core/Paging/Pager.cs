namespace SoftLegion.Common.Core.Paging
{
    public class Pager
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int RecordsCount { get; set; }
        public int TotalRecordsCount { get; set; }

        public int PagesCount { get; set; }
    }
}