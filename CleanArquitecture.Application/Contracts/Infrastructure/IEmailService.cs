﻿using CleanArquitecture.Application.Models;

namespace CleanArquitecture.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
