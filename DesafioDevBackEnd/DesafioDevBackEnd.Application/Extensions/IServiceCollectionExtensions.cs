using DesafioDevBackEnd.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using DesafioDevBackEnd.Domain.Interfaces.Repositories;
using DesafioDevBackEnd.Infrastructure.Repositories;
using DesafioDevBackEnd.Domain.Interfaces.Services;
using DesafioDevBackEnd.Service;
using DesafioDevBackEnd.Application.Interfaces;
using DesafioDevBackEnd.Application.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDevBackEnd.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext with Scoped lifetime

            #region SQL Server
            //SQL Server
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                    x => x.MigrationsAssembly("DesafioDevBackEnd.Infrastructure"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Transient
            );

            services.AddScoped<Func<AppDbContext>>((provider) => () => provider.GetService<AppDbContext>());
            #endregion

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<ITransactionRepository, TransactionRepository>()
                .AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddTransient<ITransactionService, TransactionService>()
                .AddTransient<ITransactionTypeService, TransactionTypeService>()
                .AddScoped<ITransactionApplicationService, TransactionApplicationService>();
        }
    }
}
