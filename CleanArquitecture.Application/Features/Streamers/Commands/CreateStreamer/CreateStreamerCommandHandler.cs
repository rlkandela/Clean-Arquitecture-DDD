using AutoMapper;
using CleanArquitecture.Application.Contracts.Infrastructure;
using CleanArquitecture.Application.Contracts.Persistence;
using CleanArquitecture.Application.Models;
using CleanArquitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArquitecture.Application.Features.Streamers.Commands
{
    public class CreateStreamerCommandHandler : IRequestHandler<CreateStreamerCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IEmailService emailService,
            ILogger<CreateStreamerCommandHandler> logger
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamer_entity = _mapper.Map<Streamer>(request);
            _unitOfWork.StreamerRepository.AddEntity(streamer_entity);
            var result = await _unitOfWork.Complete();
            if (result <= 0) throw new Exception("No se pudo crear el streamer");

            _logger.LogInformation($"Streamer {streamer_entity.Id} creado exitosamente");

            await SendEmail(streamer_entity);

            return streamer_entity.Id;
        }

        private async Task SendEmail(Streamer streamer)
        {
            var email = new Email
            {
                To = "rlkandela@gmail.com",
                Body = "La compania de streamer se creo correctamente",
                Subject = "Mensaje de alerta"
            };
            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception)
            {
                _logger.LogError($"Errores enviando el email de {streamer.Id}");
            }
        }
    }
}
