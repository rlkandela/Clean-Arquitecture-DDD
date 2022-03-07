using AutoFixture;
using CleanArquitecture.Domain;
using CleanArquitecture.Infrastructure.Persistence;

namespace CleanArquitecture.Application.UnitTests.Mocks
{
    public static class MockStreamerRepository
    {
        public static void AddDataStreamerRepository(StreamerDbContext FakeDb)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var streamers = fixture.CreateMany<Streamer>().ToList();
            streamers.Add(fixture
                .Build<Streamer>()
                .With(tr => tr.Id, 9001)
                .Without(tr => tr.Videos)
                .Create()
            );

            FakeDb.Streamers!.AddRange(streamers);
            FakeDb.SaveChanges();
        }
    }
}
