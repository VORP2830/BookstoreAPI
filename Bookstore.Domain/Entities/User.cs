using Bookstore.Domain.Exceptions;

namespace Bookstore.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; protected set; }
        public string UserName { get; protected set; }
        public string Password { get; protected set; }
        protected User(){ }
        public User(string name, string userName, string password)
        {
            ValidateDomain(name, userName, password);
            Active = true;
        }
        public void SetPassword(string password)
        {
            Password = password;
        }
        private void ValidateDomain(string name, string userName, string password)
        {
            BookstoreException.When(string.IsNullOrEmpty(name), "Nome é obrigatório");
            BookstoreException.When(name.Length < 3, "Nome deve conter mais de 3 caracteres");
            BookstoreException.When(string.IsNullOrEmpty(userName), "Nome é obrigatório");
            BookstoreException.When(userName.Length < 3, "Nome de usuário deve conter mais de 4 caracteres");
            BookstoreException.When(string.IsNullOrEmpty(password), "Senha é obrigatória");
            Name = name.Trim();
            UserName = userName.Trim().ToLower();
            Password = password;
        }
    }
}