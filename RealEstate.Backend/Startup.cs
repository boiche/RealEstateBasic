using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RealEstate.Backend.Models;

namespace RealEstate.Backend
{
    public class Startup
    {
        private readonly string allowedOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RealEstateDatabaseSettings>(Configuration.GetSection(nameof(RealEstateDatabaseSettings)));
            services.AddSingleton<IRealEstateDatabaseSettings>(sp => sp.GetRequiredService<IOptions<RealEstateDatabaseSettings>>().Value);
            services.AddSingleton<HousesService>();

            services.AddControllers();
            services.AddCors(options => 
            {
                options.AddPolicy(allowedOrigins, builder =>
                {
                    builder.WithOrigins("https://localhost:44356/").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
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

            app.UseCors(allowedOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
