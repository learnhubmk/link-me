namespace LinkMe.Domain.Contracts
{
    public interface IBaseRepository<T> where T : DomainEntity
    {
        Task<T> GetAsync(int id);
        //ICollection<T> GetMany(int id);
        Task<T> AddAsync(T item);
        T Update(T item);
        void Delete(T item);
    }
}
