using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Infrastructure.Persistence;
using PartnerPortal.WebApi.Filters;
using PartnerPortal.WebApi.Services;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection services)
        {
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
                options.SuppressModelStateInvalidFilter = true);

            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "Partner Portal API";
                configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });

            //services.AddSwaggerDocument();
            return services;
        }
    }
}
