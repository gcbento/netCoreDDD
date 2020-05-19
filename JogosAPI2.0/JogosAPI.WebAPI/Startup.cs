using JogosAPI.WebAPI.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JogosAPI.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true);

            builder.AddEnvironmentVariables();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Setting DBContexts
            services.AddDatabaseSetup(Configuration);

            // ASP.NET Identity Settings & JWT
            //services.AddIdentitySetup(Configuration);

            // WebAPI Config
            services.AddControllers();

            // AutoMapper Settings
            services.AddAutoMapperSetup();

            // Authorization
            //services.AddAuthSetup(Configuration);

            // Swagger Config
            services.AddSwaggerSetup();

            // Adding MediatR for Domain Events and Notifications
            //services.AddMediatR(typeof(Startup));

            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // .NET Native DI Abstraction
            services.AddDependencyInjectionSetup();

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.Configure<IISOptions>(o =>
            {
                o.ForwardClientCertificate = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();
        }
    }
}
