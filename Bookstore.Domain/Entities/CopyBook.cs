namespace Bookstore.Domain.Entities
{
    public class CopyBook : BaseEntity
    {
        public string CodeCopy { get; protected set; }
        public long BookId { get; protected set; }
        public Book Book { get; protected set; }
        protected CopyBook(){ }
        public CopyBook(string codeCopy, long bookId)
        {
            CodeCopy = codeCopy;
            BookId = bookId;
            Active = true;
        }
    }
}