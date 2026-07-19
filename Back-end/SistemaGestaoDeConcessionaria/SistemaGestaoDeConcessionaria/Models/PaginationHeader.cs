namespace SistemaGestaoDeConcessionaria.API.Models
{
    public class PaginationHeader
    {
        public int CurrentePage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public PaginationHeader(int currentPage, int itemsPerPage, int totalItems,  int totalPages)
        {
            CurrentePage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }
    }
}
