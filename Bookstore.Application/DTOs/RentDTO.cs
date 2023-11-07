namespace Bookstore.Application.DTOs
{
    public class RentDTO
    {
        public long Id { get; set; }
         public long CopyBookId { get; set; }
        public long PersonId { get; set; }
        public DateOnly RentDate { get; set; }
        public string CharOperation { get; set; }
        public bool? IsLate { get; set; }     
    }
}