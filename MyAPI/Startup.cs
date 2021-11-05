using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyAPI.DataBase;
using MyAPI.Repositories.Classes;
using MyAPI.Repositories.Interface;

namespace MyAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MimicContext>(opt =>
            {
                opt.UseSqlite("Data Source=Database\\Mimic.db");
            });

            services.AddTransient<IPalavraRepository, PalavraRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc(routes =>
            {
                routes
                .MapRoute(name: "default", template: "{controller=Palavras}/{action=ObterTodas}")
                .MapRoute(name: "api", template: "api/{controller}/{action}/{id?}");
            });
            
        }
    }
}
