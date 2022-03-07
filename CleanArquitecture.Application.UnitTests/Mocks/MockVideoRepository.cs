using AutoFixture;
using CleanArquitecture.Domain;
using CleanArquitecture.Infrastructure.Persistence;
using CleanArquitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArquitecture.Application.UnitTests.Mocks
{
    public static class MockVideoRepository
    {
        public static Mock<VideoRepository> GetVideoRepository()
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            var videos = fixture.CreateMany<Video>().ToList();
            videos.Add(fixture
                .Build<Video>()
                .With(tr => tr.CreatedBy, "system")
                .Create()
            );

            var options = new DbContextOptionsBuilder<StreamerDbContext>()
                .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{Guid.NewGuid()}")
                .Options;
            var FakeDb = new StreamerDbContext(options);
            FakeDb.Videos!.AddRange(videos);
            FakeDb.SaveChanges();

            var mockRepository = new Mock<VideoRepository>(FakeDb);

            return mockRepository;
        }
    }
}
