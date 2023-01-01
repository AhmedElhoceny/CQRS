using Application.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DependenciesInjection
{
    public static class PersistenceDependenciesInjection
    {
        public static void LoadPersistenceDependencies(this IServiceCollection serviceDescriptors , IConfiguration configration)
        {
            serviceDescriptors.AddDbContext<HrContext>(options =>
            {
                options.UseSqlServer(
                    configration.GetConnectionString("MainServer"),
                    b => b.MigrationsAssembly(typeof(HrContext).Assembly.FullName));
            });
            serviceDescriptors.AddScoped<IHrContext, HrContext>();
        }
    }
}
