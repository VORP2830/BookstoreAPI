namespace Bookstore.Domain.Exceptions
{
    public class BookstoreException : Exception
    {
        public BookstoreException(string error) : base(error) { }
        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new BookstoreException(error);
            }
        }
    }
}