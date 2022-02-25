using CleanArquitecture.Domain;

namespace CleanArquitecture.Application.Contracts.Persistence
{
    public interface IVideoRepository : IAsyncRepository<Video>
    {
        Task<Video> GetVideoByName(string nombreVideo);

        Task<IEnumerable<Video>> GetVideoByUsername(string username);
    }
}
