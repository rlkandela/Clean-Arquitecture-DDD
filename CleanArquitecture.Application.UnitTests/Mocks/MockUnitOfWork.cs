using CleanArquitecture.Application.Contracts.Persistence;
using Moq;

namespace CleanArquitecture.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var mockVideoRepository = MockVideoRepository.GetVideoRepository();
            var mockStreamerRepository = MockStreamerRepository.GetStreamerRepository();

            mockUnitOfWork.Setup(uow => uow.VideoRepository).Returns(mockVideoRepository.Object);
            mockUnitOfWork.Setup(uow => uow.StreamerRepository).Returns(mockStreamerRepository.Object);

            return mockUnitOfWork;
        }
    }
}
