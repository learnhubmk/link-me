using LinkMe.Domain;
using LinkMe.Domain.Contracts;
using LinkMe.Infrastructure.Mapping;

namespace LinkMe.Infrastructure
{
    public class BaseRepository<T> : IBaseRepository<T> where T : DomainEntity
    {
        private readonly LinkMeDbContext _dbContext;

        public BaseRepository(LinkMeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T item)
        {
            var entity = _dbContext.Add(item).Entity;
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(T item)
        {
            _dbContext.Remove(item);
            _dbContext.SaveChanges();
        }

        public T Get(int id)
        {
            return _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public T Update(T item)
        {
            var entityEntry = _dbContext.Update(item);
            _dbContext.SaveChanges();
            return entityEntry.Entity;
        }
    }
}
