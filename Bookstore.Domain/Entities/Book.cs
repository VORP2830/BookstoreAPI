using Bookstore.Domain.Exceptions;

namespace Bookstore.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; protected set; }
        public string Author { get; protected set; }
        public string ISBN { get; protected set; }
        public IEnumerable<CopyBook> CopyBooks { get; set; }
        protected Book(){ }
        public Book(string title, string author, string isbn)
        {
            ValidateDomain(title, author, isbn);
            Active = true;
        }
        private void ValidateDomain(string title, string author, string isbn)
        {
            BookstoreException.When(string.IsNullOrEmpty(title), "Titulo é obrigatório");
            BookstoreException.When(title.Length < 3, "Titulo deve conter mais de 3 caracteres");
            BookstoreException.When(string.IsNullOrEmpty(author), "Autor é obrigatório");
            BookstoreException.When(author.Length < 3, "Autor deve conter mais de 3 caracteres");
            BookstoreException.When(string.IsNullOrEmpty(isbn), "ISBN é obrigatório");
            BookstoreException.When(isbn.Length != 13, "ISBN deve conter 13 caracteres");
            Title = title.Trim();
            Author = author.Trim();
            ISBN = isbn;
        }
    }
}