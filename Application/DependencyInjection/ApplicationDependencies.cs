using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.DependencyInjection
{
    public static class ApplicationDependencies
    {
        public static void LoadDependencies(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
