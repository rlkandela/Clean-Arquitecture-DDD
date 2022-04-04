using AutoMapper;
using CleanArquitecture.Application.Contracts.Infrastructure;
using CleanArquitecture.Application.Features.Streamers.Commands.DeleteStreamer;
using CleanArquitecture.Application.Mappings;
using CleanArquitecture.Application.UnitTests.Mocks;
using CleanArquitecture.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArquitecture.Application.UnitTests.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<DeleteStreamerCommandHandler>> _logger;

        public DeleteStreamerCommandHandlerXUnitTests()
        {
            var mapperConfig = new MapperConfiguration(c => c.AddProfile<MappingProfile>());
            _mapper = mapperConfig.CreateMapper();

            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);
            
            _logger = new Mock<ILogger<DeleteStreamerCommandHandler>>();
        }

        [Fact]
        public async Task DeleteStreamerCommandHandler_InputStreamer_ReturnsUnit()
        {
            var streamerInput = new DeleteStreamerCommand()
            {
                Id = 9001
            };

            var handler = new DeleteStreamerCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.Handle(streamerInput, CancellationToken.None);

            result.ShouldBeOfType<Unit>();
        }
    }
}
