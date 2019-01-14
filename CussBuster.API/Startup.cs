using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using CussBuster.Database.Context;
using CussBuster.Database.Repository;
using CussBuster.API.Services;
using CussBuster.API.Repository;
using CussBuster.API.DataAccess;

namespace CussBuster.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var hostname = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "localhost";
            var database = Environment.GetEnvironmentVariable("SQLSERVER_DB") ?? "CussBusterDB";
            var user = Environment.GetEnvironmentVariable("SQLSERVER_USER") ?? "sa";
            var password = Environment.GetEnvironmentVariable("SQLSERVER_SA_PASSWORD") ?? "Levvel1!";
            var connection = $"Data Source={hostname};Database={database};Integrated Security=False;User ID={user};Password={password};MultipleActiveResultSets=true";

            services.AddDbContext<CussBusterContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICurseWordsRepository, CurseWordsRepository>();
            services.AddScoped<IMessageService, MessageService>();

            var provider = services.BuildServiceProvider();
            
            services.AddSingleton<IBadWordCache, BadWordCache>(sp =>
            {
                return new BadWordCache
                {
                    CurseWords = provider.GetService<ICurseWordsRepository>().Queryable()
                };
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
                app.UseHttpsRedirection();
            }

            app.UseMvc();
        }
    }
}
