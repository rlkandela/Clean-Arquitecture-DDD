using CleanArquitecture.Infrastructure.Persistence;
using CleanArquitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArquitecture.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            var options = new DbContextOptionsBuilder<StreamerDbContext>()
                .UseInMemoryDatabase(databaseName: $"StreamerDbContext-{Guid.NewGuid()}")
                .Options;
            var FakeDb = new StreamerDbContext(options);

            FakeDb.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(FakeDb);

            return mockUnitOfWork;
        }
    }
}
