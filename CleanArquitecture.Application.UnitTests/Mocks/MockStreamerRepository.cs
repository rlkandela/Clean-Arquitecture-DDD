using AutoFixture;
using CleanArquitecture.Domain;
using CleanArquitecture.Infrastructure.Persistence;
using CleanArquitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArquitecture.Application.UnitTests.Mocks
{
    public static class MockStreamerRepository
    {
        public static Mock<StreamerRepository> GetStreamerRepository()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var streamers = fixture.CreateMany<Streamer>().ToList();

            var options = new DbContextOptionsBuilder<StreamerDbContext>()
                .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{Guid.NewGuid()}")
                .Options;
            var FakeDb = new StreamerDbContext(options);
            FakeDb.Streamers!.AddRange(streamers);
            FakeDb.SaveChanges();

            var mockRepository = new Mock<StreamerRepository>(FakeDb);

            return mockRepository;
        }
    }
}
