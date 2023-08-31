namespace LogisticSolution.Utils
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Completed { get; set; }
        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
            this.Completed = 1;
        }

        public PaginationFilter(int pageNumber, int pageSize, int completed)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
            this.Completed = completed;
        } 
    }
}
