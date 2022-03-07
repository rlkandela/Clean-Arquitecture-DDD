using AutoFixture;
using CleanArquitecture.Domain;
using CleanArquitecture.Infrastructure.Persistence;

namespace CleanArquitecture.Application.UnitTests.Mocks
{
    public static class MockVideoRepository
    {
        public static void AddDataVideoRepository(StreamerDbContext FakeDb)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var videos = fixture.CreateMany<Video>().ToList();
            videos.Add(fixture
                .Build<Video>()
                .With(tr => tr.CreatedBy, "system")
                .Without(tr => tr.Streamer)
                .Without(tr => tr.Actores)
                .Without(tr => tr.Director)
                .Create()
            );

            FakeDb.Videos!.AddRange(videos);
            FakeDb.SaveChanges();
        }
    }
}
