using CleanArquitecture.Domain.Common;

namespace CleanArquitecture.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IAsyncRepository<TEntity>? Repository<TEntity>() where TEntity : BaseDomainModel;

        IVideoRepository VideoRepository { get; }

        IStreamerRepository StreamerRepository { get; }

        Task<int> Complete();
    }
}
