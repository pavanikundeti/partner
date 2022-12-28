using PartnerPortal.Application.Common.Interfaces;

namespace PartnerPortal.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }

}
