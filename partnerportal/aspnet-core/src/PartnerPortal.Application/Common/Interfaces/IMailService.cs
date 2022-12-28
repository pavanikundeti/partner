using PartnerPortal.Domain.Entities;
using PartnerPortal.Domain.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Common.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
