using helpMeFest.Data;
using helpMeFest.Data.Repositories;
using helpMeFest.Models.Contract;
using helpMeFest.Models.Contract.Repositories;
using helpMeFest.Models.Contract.Services;
using helpMeFest.Models.Contract.UnitOfWork;
using helpMeFest.Services.Events;
using helpMeFest.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace helpMeFest.Api.Utils.ExtensionMethods
{
    public static class StartUpExtension
    {
        public static void ConfigureServiceLayer (this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEventService, EventService>();  
            services.AddScoped<IUserEventService, UserEventService>();
        }

        public static void ConfigureDataLayer (this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
