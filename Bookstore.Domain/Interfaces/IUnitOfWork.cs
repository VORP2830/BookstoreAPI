namespace Bookstore.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IPersonRepository PersonRepository { get; }
        IBookRepository BookRepository { get; }
        ICopyBookRepository CopyBookRepository { get; }
        IRentRepository RentRepository { get; }
        Task<bool> SaveChangesAsync(); 
    }
}