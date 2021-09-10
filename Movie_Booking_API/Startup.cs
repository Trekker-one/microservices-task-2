using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Movie_Booking_API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "Movie_Booking_API", 
                    Version = "v1",
                    Description = "Sample Movie Booking API --- Based on In-Meomery DB",
                    TermsOfService = new Uri("https://www.a-star.edu.sg/terms-and-conditions"),
                    Contact = new OpenApiContact
                    {
                        Name = "Huang Yuzhe",
                        Email = "huangyuzhe2019@gmail.com",
                        Url = new Uri("https://www.a-star.edu.sg/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License Test",
                        Url = new Uri("https://example.license.com")
                    }
                });
            });

            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("db_local"));

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie_Booking_API v1"));
            }

            //var context = app.ApplicationServices.GetService<ApiContext>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
