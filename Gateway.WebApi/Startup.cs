using Microsoft.AspNetCore.Builder;
using Ocelot.Values;
using Ocelot.DependencyInjection;
using FluentAssertions.Common;


namespace Gateway.WebApi
{
    public class Startup
    {
        public void Configure(IServiceCollection services)
        {
            services.AddControllers();
            services.AddOcelot();
        }
    }
}
