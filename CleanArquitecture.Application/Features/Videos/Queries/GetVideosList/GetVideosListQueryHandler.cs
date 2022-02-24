using AutoMapper;
using CleanArquitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArquitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQueryHandler : IRequestHandler<GetVideosListQuery, IEnumerable<VideosVM>>
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IMapper _mapper;

        public GetVideosListQueryHandler(IVideoRepository videoRepository, IMapper mapper)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VideosVM>> Handle(GetVideosListQuery request, CancellationToken cancellationToken)
        {
            var videoList = await _videoRepository.GetVideoByUsername(request.Username);

            //return _mapper.Map<IEnumerable<VideosVM>>(videoList);
            return new List<VideosVM>();
        }
    }
}
