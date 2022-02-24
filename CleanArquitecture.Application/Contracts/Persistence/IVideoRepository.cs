using CleanArquitecture.Domain;

namespace CleanArquitecture.Application.Contracts.Persistence
{
    public interface IVideoRepository : IAsyncRepository<Video>
    {
        Task<IEnumerable<Video>> GetVideoByName(string nombreVideo);
    }
}
