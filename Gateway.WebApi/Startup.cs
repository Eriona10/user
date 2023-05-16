using Microsoft.AspNetCore.Builder;
using Ocelot.Values;
using Ocelot.DependencyInjection;
using FluentAssertions.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using System.Reflection;
 using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Gateway.WebApi
{
    public class Startup
    {
       public void ConfigureServices(IServiceCollection services)
       {
           services.AddControllers(); 
        }

        

    }
}
