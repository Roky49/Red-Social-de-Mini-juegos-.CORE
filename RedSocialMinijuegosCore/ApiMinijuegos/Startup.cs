using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMinijuegos.Data;
using ApiMinijuegos.Repositories;
using ApiMinijuegos.Token;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiMinijuegos
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
            HelperToken helpertoken = new HelperToken(this.Configuration);
            String cadenaconexion = Configuration.GetConnectionString("cadenaazure");
            services.AddDbContext<MinijuegosContex>(options => options.UseSqlServer(cadenaconexion));
            services.AddTransient<IRepositoryMinijuegos,RepositoryMinijuegos>();
                services.AddAuthentication(helpertoken.GetAuthOptions())
                    .AddJwtBearer(helpertoken.GetJwtOptions());
                services.AddMvc();
            



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
