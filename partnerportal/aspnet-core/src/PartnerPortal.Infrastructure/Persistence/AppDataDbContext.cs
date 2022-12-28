using Microsoft.EntityFrameworkCore;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Domain.Model;


namespace PartnerPortal.Data
{
    public class AppDataDbContext : DbContext
    {
        public AppDataDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EmailTemplates> EmailTemplates { get; set; }
        public DbSet<MailRequest> MailRequests { get; set; }
        public object MailRequest { get; internal set; }
    }
}
