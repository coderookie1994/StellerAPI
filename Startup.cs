using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Docker.DotNet;
using StellerAPI.StellerCore;
using StellerAPI.Manager;
using StellerAPI.Repository;

namespace StellerAPI
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
            services.AddMvc();
            services.AddSingleton<IDockerClientWrapper, DockerClientWrapper>();
            services.Configure<DbConnectionSettings>(options => {
                options.ConnectionString = 
                    Configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = 
                    Configuration.GetSection("MongoConnection:Database").Value;
                
                options.Collections = 
                    Configuration.GetSection("MongoConnection:Collections").Get<Collections>();
            });
            services.AddTransient<IEnvironmentManager, EnvironmentManager>();
            services.AddTransient<IContainerRepository, ContainerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
