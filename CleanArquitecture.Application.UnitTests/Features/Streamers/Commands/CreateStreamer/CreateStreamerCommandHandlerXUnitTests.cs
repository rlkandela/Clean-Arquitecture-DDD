using AutoMapper;
using CleanArquitecture.Application.Contracts.Infrastructure;
using CleanArquitecture.Application.Features.Streamers.Commands;
using CleanArquitecture.Application.Mappings;
using CleanArquitecture.Application.UnitTests.Mocks;
using CleanArquitecture.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArquitecture.Application.UnitTests.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<IEmailService> _emailService;
        private readonly Mock<ILogger<CreateStreamerCommandHandler>> _logger;

        public CreateStreamerCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);

            var mapperConfig = new MapperConfiguration(c => c.AddProfile<MappingProfile>());
            _mapper = mapperConfig.CreateMapper();

            _emailService = new Mock<IEmailService>();
            _logger = new Mock<ILogger<CreateStreamerCommandHandler>>();
        }

        [Fact]
        public async Task CreateStreamerCommand_InputStreamer_ReturnsNumber()
        {
            var input = new CreateStreamerCommand()
            {
                Nombre = "Raul Stream",
                Url = "raulstream.com"
            };

            var handler = new CreateStreamerCommandHandler(_unitOfWork.Object, _mapper, _emailService.Object, _logger.Object);
            var output = await handler.Handle(input, CancellationToken.None);

            output.ShouldBeOfType<int>();
        }
    }
}
