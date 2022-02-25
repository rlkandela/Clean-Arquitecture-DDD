using MediatR;

namespace CleanArquitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQuery : IRequest<IEnumerable<VideosVM>>
    {
        public string Username { get; set; } = String.Empty;

        public GetVideosListQuery(string username)
        {
            this.Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
