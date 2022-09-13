using ApiProject.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Infrastructure
{
    public static class ServiceCollectionExtention
    {        
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddScoped<IBattleshipService, BattleshipService>();
            services.AddScoped<ICacheService, CacheService>();

            return services;
        }
    }
}
