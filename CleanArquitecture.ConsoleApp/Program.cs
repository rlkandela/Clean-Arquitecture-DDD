using CleanArquitecture.Data;
using CleanArquitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();
await QueryFilter();


async Task QueryFilter()
{
    var streamers = await dbContext!.Streamers!.Where(x => x.Nombre == "Netflix").ToListAsync();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}