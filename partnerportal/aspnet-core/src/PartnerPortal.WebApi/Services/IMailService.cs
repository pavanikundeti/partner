using PartnerPortal.Domain.Model;
using MailKit;

namespace PartnerPortal.WebApi.Services
{
    public interface  IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
