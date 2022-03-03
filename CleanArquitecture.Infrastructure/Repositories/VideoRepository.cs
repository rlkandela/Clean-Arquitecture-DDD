using CleanArquitecture.Application.Contracts.Persistence;
using CleanArquitecture.Domain;
using CleanArquitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArquitecture.Infrastructure.Repositories
{
    public class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
        public VideoRepository(StreamerDbContext context) : base(context)
        {
        }

        public async Task<Video?> GetVideoByName(string nombreVideo)
        {
            return await FirstOrDefaultAsync(v => v.Equals(nombreVideo));
        }

        public async Task<IEnumerable<Video>> GetVideoByUsername(string username)
        {
            return await _context.Videos!.Where(v => v.CreatedBy!.Equals(username)).ToListAsync();
        }
    }
}
