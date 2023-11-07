namespace Bookstore.Application.DTOs
{
    public class PersonDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateOnly BirthDay { get; set; }
        public string Address { get; set; }
    }
}