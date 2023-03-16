using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReservationVols.Domain.Interface;
using ReservationVols.Infrastructure.Database;
using ReservationVols.Infrastructure.Repository;

namespace ReservationVols.Api
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionStringSqlite = _configuration.GetConnectionString("DefaultConnection");
            //var connectionStringSqlite = $"DataSource=..\\ReservationVols.Infrastructure\\Reservation.db";

            services.AddDbContext<ReservationContext>(
                options => options.UseSqlite(connectionStringSqlite));

            var backOfficeConfigSection = _configuration.GetSection("ReservationBackOffice:BaseAdress");

            if (backOfficeConfigSection.Exists())
            {
                //Add Cors for IHM
                services.AddCors(opt =>
                {
                    opt.AddPolicy("CorsReservationBackOffice", policy =>
                    {
                        policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins(backOfficeConfigSection.Value);
                    });
                });
            }

            services.AddControllers();
            services.AddSwaggerGen();

            // Inject main classes
            services
                .AddTransient<IReservation, ReservationRepository>()
                .AddTransient<IVol, VolRepository>();
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
            app.UseCors("CorsReservationBackOffice");
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
