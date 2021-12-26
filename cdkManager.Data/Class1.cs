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
        protected readonly RepositoryContext RepositoryPatternDemoContext;

        public Repository(RepositoryContext repositoryPatternDemoContext)
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

    public interface IStackRepository : IRepository<Models.Stack>
    {
        Task<Models.Stack> GetProductByIdAsync(int id);
    }

    public class StackRepository : Repository<Models.Stack>, IStackRepository
    {
        public StackRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Task<Models.Stack> GetProductByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }
    }

    public partial class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Models.Stack> Stack { get; set; }
        public virtual DbSet<Models.Bucket> Bucket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Stack>(entity =>
            {
                entity.Property(e => e.StackName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Models.Bucket>(entity =>
            {
                entity.Property(e => e.BucketName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}