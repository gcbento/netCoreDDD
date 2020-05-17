using JogosAPI.Application.Interfaces;
using JogosAPI.Application.Services;
using JogosAPI.Domain.Interfaces;
using JogosAPI.Domain.Validations;
using JogosAPI.Domain.Validations.Interfaces;
using JogosAPI.Infra.Data.Context;
using JogosAPI.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JogosAPI.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IGameAppService, GameAppService>();
            services.AddScoped<IAccountAppService, AccountAppService>();
            services.AddScoped<IGameAccountAppService, GameAccountAppService>();
            services.AddScoped<IPurchaseAppService, PurchaseAppService>();
            services.AddScoped<ISaleAppService, SaleAppService>();
            services.AddScoped<IWishGameAppService, WishGameAppService>();

            // Validation
            services.AddScoped<IGameValidation, GameValidation>();
            services.AddScoped<IAccountValidation, AccountValidation>();
            services.AddScoped<IGameAccountValidation, GameAccountValidation>();
            services.AddScoped<IPurchaseValidation, PurchaseValidation>();
            services.AddScoped<ISaleValidation, SaleValidation>();
            services.AddScoped<IWishGameValidation, WishGameValidation>();

            // Infra - Data
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IGameAccountRepository, GameAccountRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IWishGameRepository, WishGameRepository>();
            services.AddScoped<ILoggerRepository, LoggerRepository>();
            services.AddDbContext<JogosAPIContext>(ServiceLifetime.Transient);
        }
    }
}
