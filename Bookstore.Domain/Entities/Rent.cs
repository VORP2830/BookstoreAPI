using Bookstore.Domain.Exceptions;

namespace Bookstore.Domain.Entities
{
    public class Rent : BaseEntity
    {
        public long CopyBookId { get; set; }
        public CopyBook CopyBook { get; set; }
        public long PersonId { get; set; }
        public Person Person { get; set; }
        public DateOnly RentDate { get; set; }
        public string CharOperation { get; set; }
        public bool? IsLate { get; set; }              
        protected Rent() { }
        public Rent(long copyBookId, long personId, string charOperation, bool isLate)
        {
            CopyBookId = copyBookId;
            PersonId = personId;
            if(charOperation != "S" && charOperation != "E") throw new BookstoreException("Operacao so pode ser S para saida e E para entrada");
            CharOperation = charOperation;
            IsLate = isLate;
            Active = true;
        }
    }
}
