using MediatR;

namespace CleanArquitecture.Application.Features.Streamers.Commands
{
    public class CreateStreamerCommand : IRequest<int>
    {
        public string Nombre { get; set; } = String.Empty;

        public string Url { get; set; } = String.Empty;
    }
}
