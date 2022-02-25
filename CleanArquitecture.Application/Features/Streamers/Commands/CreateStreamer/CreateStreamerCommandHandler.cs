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
        private readonly IStreamerRepository _streamerRepositroy;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateStreamerCommandHandler> _logger;

        public CreateStreamerCommandHandler(
            IStreamerRepository streamerRepositroy,
            IMapper mapper,
            IEmailService emailService,
            ILogger<CreateStreamerCommandHandler> logger
        )
        {
            _streamerRepositroy = streamerRepositroy;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(CreateStreamerCommand request, CancellationToken cancellationToken)
        {
            var streamer_entity = _mapper.Map<Streamer>(request);
            var new_streamer = await _streamerRepositroy.AddAsync(streamer_entity);

            _logger.LogInformation($"Streamer {new_streamer.Id} creado exitosamente");

            await SendEmail(new_streamer);

            return new_streamer.Id;
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
