namespace Comp214_TeamProject.Database
{
    /// <summary>
    /// Class that will be used for query pagination.
    /// </summary>
    public class QueryPage
    {
        // The page number.
        public int PageNumber { get; }

        // The page size.
        public int PageSize { get; }

        /// <summary>
        /// Creates a new QueryPage with the given pageNumber and pageSize
        /// </summary>
        /// <param name="pageNumber">The number of the page to be retrieved</param>
        /// <param name="pageSize">The number of elements per page.</param>
        public QueryPage(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}