using back_end.Entidades;
using back_end.Filtros;
using back_end.Repositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end
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

            //automaper
            services.AddAutoMapper(typeof(Startup));


            //datos
            services.AddDbContext<ApplicationDbContext>(options=>
            options.UseSqlServer( Configuration.GetConnectionString("defaultConnection"))
            );

            //solo para navegadores web
            services.AddCors(
                options=>
                {
                    var frontEnd = Configuration.GetValue<string>("frontend_url");
                    options.AddDefaultPolicy(builder =>

                    {
                        builder.WithOrigins(frontEnd).AllowAnyMethod().AllowAnyHeader()
                        .WithExposedHeaders(new string[] { "cantidadTotalRegistros" });//va sin / al final

                    });
                });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
            services.AddTransient<IRepositorioEnMemoria, RepositorioEnMemoria>();
            services.AddTransient<MiFiltroDeAccion>();

            services.AddControllers( option=>
            {
                //se registra el filtro de forma global 
                option.Filters.Add(typeof(FiltroDeExcepcion));
            }
                
                
                );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "back_end", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "back_end v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
