using cdkManager.Models;
using Microsoft.EntityFrameworkCore;

namespace cdkManager.Data
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly ApplicationDbContext RepositoryPatternDemoContext;

        public Repository(ApplicationDbContext repositoryPatternDemoContext)
        {
            RepositoryPatternDemoContext = repositoryPatternDemoContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return RepositoryPatternDemoContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await RepositoryPatternDemoContext.AddAsync(entity);
                await RepositoryPatternDemoContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                RepositoryPatternDemoContext.Update(entity);
                await RepositoryPatternDemoContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
    }

    public interface IBucketRepository : IRepository<Models.Bucket>
    {

    }

    public class BucketRepository : Repository<Models.Bucket>, IBucketRepository
    {
        public BucketRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {
        }
    }

    public interface IStackRepository : IRepository<Models.Stack>
    {
        Task<Stack?> GetProductByIdAsync(int id);
    }

    public class StackRepository : Repository<Models.Stack>, IStackRepository
    {
        public StackRepository(ApplicationDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public Task<Stack?> GetProductByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }
    }

 
}