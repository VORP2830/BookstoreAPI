using Bookstore.Domain.Exceptions;

namespace Bookstore.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string Name { get; protected set; }
        public string CPF { get; protected set; }
        public DateOnly BirthDay { get; protected set; }
        public string Address { get; protected set; }
        public IEnumerable<Rent> Rents { get; set; }
        protected Person(){ }
        public Person(string name, string cpf, DateOnly birthDay, string address)
        {
            ValidateDomain(name, cpf, birthDay, address);
            Active = true;
        }
        private void ValidateDomain(string name, string cpf, DateOnly birthDay, string address)
        {
            BookstoreException.When(string.IsNullOrEmpty(name), "Nome é obrigatório");
            BookstoreException.When(name.Length < 3, "Nome deve conter mais de 3 caracteres");
            BookstoreException.When(cpf.Length != 11, "O CPF deve conter 11 caracteres");
            Name = name.Trim();
            CPF = cpf;
            BirthDay = birthDay;
            Address = address.Trim();
        }
    }
}