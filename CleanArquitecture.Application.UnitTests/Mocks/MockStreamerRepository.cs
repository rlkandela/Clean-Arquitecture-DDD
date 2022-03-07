using AutoFixture;
using CleanArquitecture.Application.Contracts.Persistence;
using CleanArquitecture.Domain;
using Moq;

namespace CleanArquitecture.Application.UnitTests.Mocks
{
    public static class MockStreamerRepository
    {
        public static Mock<IStreamerRepository> GetStreamerRepository()
        {
            var fixture = new Fixture();
            var streamers = fixture.CreateMany<Streamer>().ToList();

            var mockRepository = new Mock<IStreamerRepository>();
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(streamers);

            return mockRepository;
        }
    }
}
