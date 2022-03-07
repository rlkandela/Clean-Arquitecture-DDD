using AutoFixture;
using CleanArquitecture.Application.Contracts.Persistence;
using CleanArquitecture.Domain;
using Moq;

namespace CleanArquitecture.Application.UnitTests.Mocks
{
    public static class MockVideoRepository
    {
        public static Mock<IVideoRepository> GetVideoRepository()
        {
            var fixture = new Fixture();
            var videos = fixture.CreateMany<Video>().ToList();

            var mockRepository = new Mock<IVideoRepository>();
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(videos);

            return mockRepository;
        }
    }
}
