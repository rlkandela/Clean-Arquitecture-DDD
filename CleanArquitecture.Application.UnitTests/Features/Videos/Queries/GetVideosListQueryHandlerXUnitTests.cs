using AutoMapper;
using CleanArquitecture.Application.Contracts.Persistence;
using CleanArquitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArquitecture.Application.Mappings;
using CleanArquitecture.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArquitecture.Application.UnitTests.Features.Videos.Queries
{
    public class GetVideosListQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public GetVideosListQueryHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetVideoListTest()
        {
            var handler = new GetVideosListQueryHandler(_unitOfWork.Object, _mapper);
            var result = await handler.Handle(new GetVideosListQuery("system"), CancellationToken.None);

            result.ShouldBeOfType<List<VideosVM>>();
            result.Count().ShouldBeGreaterThanOrEqualTo(1);
        }
    }
}
