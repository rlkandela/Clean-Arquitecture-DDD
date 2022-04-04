using AutoMapper;
using CleanArquitecture.Application.Contracts.Persistence;
using CleanArquitecture.Application.Exceptions;
using CleanArquitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArquitecture.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DeleteStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamer_to_delete = await _unitOfWork.StreamerRepository.GetByIdAsync(request.Id);
            if (streamer_to_delete == null)
            {
                _logger.LogError($"{request.Id} streamer no existe en el sistema");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }
            _unitOfWork.StreamerRepository.DeleteEntity(streamer_to_delete);
            var ret = await _unitOfWork.Complete();
            if (ret <= 0) throw new Exception($"No se pudo borrar el streamer {request.Id}");
            _logger.LogInformation($"El ${request.Id} fue eliminado con exito");
            return Unit.Value;
        }
    }
}
