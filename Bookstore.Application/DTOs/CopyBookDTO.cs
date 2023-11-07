namespace Bookstore.Application.DTOs
{
    public class CopyBookDTO
    {
        public long Id { get; set; }
         public string CodeCopy { get; set; }
        public long BookId { get; set; }
    }
}