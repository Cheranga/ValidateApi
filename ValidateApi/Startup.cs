using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ValidateApi.Configs;
using ValidateApi.Exceptions;
using ValidateApi.Services;

namespace ValidateApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterDependencies(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();

            services.Configure<NotificationServiceConfig>(Configuration.GetSection("Notification"));
            services.AddSingleton(provider =>
            {
                var config = provider.GetRequiredService<IOptions<NotificationServiceConfig>>().Value;
                if ( config == null || !config.IsValid())
                {
                    throw new InvalidConfigurationException(typeof(NotificationServiceConfig), "Invalid config");
                }
                return config;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
