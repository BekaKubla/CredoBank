using KredoBank.Application.Services.JWTService;
using KredoBank.Application.Services.UserContext;
using KredoBank.Application.Statements.Queries.GetStatement;
using KredoBank.Domain.Repositories;
using KredoBank.Domain.SeedWork;
using KredoBank.Infrastructure.Persistence.Repositories;
using KredoBank.Infrastructure.Persistence.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace KredoBank.Infrastructure.DepedencyContainer
{
    public class DepedencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IStatementRepository, StatementRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<UserContextService>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(DepedencyContainer).Assembly);
            services.AddMediatR(typeof(GetStatementQuery).Assembly);
        }
    }
}
