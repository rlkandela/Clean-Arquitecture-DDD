using CleanArquitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArquitecture.Infrastructure.Persistence
{
    public class StreamerDbContextSeed
    {
        public static async Task SeedAsync(StreamerDbContext context, ILogger<StreamerDbContext> logger)
        {
            await SeedStreamers(context, logger);
        }

        private static async Task SeedStreamers(StreamerDbContext context, ILogger<StreamerDbContext> logger)
        {
            if (context.Streamers!.Any()) return;
            await context.Streamers!.AddRangeAsync(GetPreconfiguredStreamers());
            await context.SaveChangesAsync();
            logger.LogInformation($"Estamos insertando nuevos records al db {typeof(Streamer).Name}");
            return;
        }

        private static IEnumerable<Streamer> GetPreconfiguredStreamers()
        {
            return new List<Streamer>
            {
                new Streamer {CreatedBy = "rlkandela", Nombre = "Maxi HBP", Url = "http://hbp.com"},
                new Streamer {CreatedBy = "rlkandela", Nombre = "Amazon VIP", Url = "http://amazonvip.com"}
            };
        }
    }
}
