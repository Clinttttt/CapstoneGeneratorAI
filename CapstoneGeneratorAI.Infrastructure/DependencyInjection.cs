using CapstoneGeneratorAI.Domain.Interface;

using CapstoneGeneratorAI.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneGeneratorAI.Infrastructure
{
   public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            
      
            service.AddScoped<IPromptServices, PromptServices>();
            service.AddHttpClient();
            service.AddScoped<PromptApiService>();
            return service;
        }
    }
}
