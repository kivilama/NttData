using NttDataApi.Interfaces;
using NttDataApi.Services;
using NttDataApi.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace NttDataApi.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void InjectApiServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITransactionService, TransactionService>();

        }
        public static void InjectRepositoriesDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
        }

    }
}
