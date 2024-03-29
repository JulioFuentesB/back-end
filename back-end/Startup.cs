using AutoMapper;
using back_end.Entidades;
using back_end.Filtros;
using back_end.Repositorio;
using back_end.Utilidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace back_end
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //identity mapea el valor del email por otro que se usa en raitings, se coloca esta linea para evitar eso
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //automaper
            services.AddAutoMapper(typeof(Startup));
            services.AddSingleton(provider =>
                 new MapperConfiguration(config =>
                 {
                     var geometryFactory = provider.GetRequiredService<GeometryFactory>();
                     config.AddProfile(new AutoMapperProfiles(geometryFactory));
                 }).CreateMapper());

            services.AddSingleton<GeometryFactory>(NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326));///numero para mediciones en a tierra


            services.AddTransient<IAlmacenadorArchivos, AlmacenadorAzureStorage>();
            //services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosLocal>();

            //datos
            services.AddDbContext<ApplicationDbContext>(options=>
            options.UseSqlServer( Configuration.GetConnectionString("defaultConnection"), 
            sqlServer=>sqlServer.UseNetTopologySuite())//paquetes query espaciales 
            );



            //solo para navegadores web
            //services.AddCors(
            //    options=>
            //    {
            //        var frontEnd = Configuration.GetValue<string>("frontend_url");
            //        options.AddDefaultPolicy(builder =>

            //        {
            //            builder.WithOrigins(frontEnd).AllowAnyMethod().AllowAnyHeader()
            //            .WithExposedHeaders(new string[] { "cantidadTotalRegistros" });//va sin / al final

            //        });
            //    });


            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(builder =>
            //    builder.WithOrigins("https://localhost:44327")
            //           .AllowAnyMethod()
            //           .AllowAnyHeader());
            //});

            services.AddIdentity<IdentityUser, IdentityRole>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();


            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(opciones =>
            //opciones.TokenValidationParameters = new TokenValidationParameters
            //{
            //    ValidateIssuer = false,
            //    ValidateAudience = false,
            //    ValidateLifetime = true,// no use un toquen de manera indefinida, ejmplo un dia
            //    ValidateIssuerSigningKey = true,//validar la firma con la llave privada
            //    IssuerSigningKey = new SymmetricSecurityKey(
            //        Encoding.UTF8.GetBytes(Configuration["llavejwt"])),
            //    ClockSkew = TimeSpan.Zero//no tenga diferencias de tiempo si el token vencio
            //});

            //services.AddAuthorization(opciones =>
            //{
            //    opciones.AddPolicy("EsAdmin", policy => policy.RequireClaim("role", "admin"));
            //});

            services.AddTransient<IRepositorioEnMemoria, RepositorioEnMemoria>();
            services.AddTransient<MiFiltroDeAccion>();

   
            services.AddHttpContextAccessor();

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


            ///usar archivos estaricos
            ///
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseCors();


            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
