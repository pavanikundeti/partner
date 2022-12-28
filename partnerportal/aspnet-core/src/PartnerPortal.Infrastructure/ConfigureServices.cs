using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Infrastructure.Identity;
using PartnerPortal.Infrastructure.Persistence.Interceptors;
using PartnerPortal.Infrastructure.Persistence;
using PartnerPortal.Infrastructure.Services;
using PartnerPortal.Infrastructure.Files;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
                        
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<ApplicationDbContextInitialiser>();

            services
                .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            services.AddAuthorization(options =>
                options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

            return services;
        }
    }
}