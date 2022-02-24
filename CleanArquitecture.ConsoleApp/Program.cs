using CleanArquitecture.Data;
using CleanArquitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();
//await QueryFilter();
//await AddNewStreamerWithVideo();
//await AddNewActorWithVideo();
//await AddNewDirectorWithVideo();
await MultipleEntitiesQuery();


async Task MultipleEntitiesQuery()
{
    //var videoWithActores = await dbContext!.Videos!.Include(q => q.Actores).FirstOrDefaultAsync(q => q.Id == 1);

    //var actor = await dbContext!.Actores!.Select(q => q.Nombre).ToListAsync();

    var videoWithDirector = await dbContext!.Videos!
        .Where(q => q.Director != null)
        .Include(q => q.Director)
        .Select(q =>
            new
            {
                DirectorNombreCompleto = $"{q.Director!.Nombre} {q.Director!.Apellido}",
                Pelicula = q.Nombre
            }
        )
        .ToListAsync();
    foreach (var video in videoWithDirector)
    {
        Console.WriteLine($"{video.Pelicula} - {video.DirectorNombreCompleto}");
    }
}

async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Nombre = "Lorenzo",
        Apellido = "Basteri",
        VideoId = dbContext!.Videos.FirstOrDefault(e => e.Nombre == "Mad Max")!.Id
    };

    await dbContext.AddAsync(director);
    await dbContext.SaveChangesAsync();
}

async Task AddNewActorWithVideo()
{
    var actor = new Actor
    {
        Nombre = "Brad",
        Apellido = "Pit"
    };

    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = dbContext!.Videos!.FirstOrDefault(e => e.Nombre == "Mad Max")!.Id,
    };

    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideo()
{
    var pantaya = new Streamer{Nombre = "Pantaya"};
    var video = new Video
    {
        Nombre = "Hunger Games",
        Streamer = pantaya
    };

    await dbContext.AddAsync(video);
    await dbContext.SaveChangesAsync();
}

async Task QueryFilter()
{
    var streamers = await dbContext!.Streamers!.Where(x => x.Nombre == "Netflix").ToListAsync();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}