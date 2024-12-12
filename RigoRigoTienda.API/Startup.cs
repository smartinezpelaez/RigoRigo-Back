using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RigoRigoTienda.BL.DTOs;
using RigoRigoTienda.DataAccess.Context;
using RigoRigoTienda.DataAccess.Interfaces;
using RigoRigoTienda.DataAccess.Repositories;
using RigoRigoTienda.DataAccess.Services;
using AutoMapper;
using RigoRigoTienda.BusinessLogic.Interfaces;
using RigoRigoTienda.BusinessLogic.Services;
using System;

namespace RigoRigoTienda.API
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
            // Configurar DbContext
            services.AddDbContext<RigoRigoTiendaBdContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RigoRigoTiendaBd")));

            // Inyección de dependencias para los repositorios
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IDetallePedidoRepository, DetallePedidoRepository>();

            // Registrar el servicio de procedimientos almacenados
            services.AddScoped<IStoreProceduresService, StoreProceduresService>();

            // Registrar el servicio
            services.AddScoped<IPedidoService, PedidoService>();

            //Probar bd
            services.AddScoped<TestDbConnectionService>();


            services.AddAutoMapper(typeof(MappingProfile));

            // Agregar Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Rigo Rigo Tienda API",
                    Version = "v1",
                    Description = "API para la gestión de pedidos y productos de la tienda Rigo Rigo"
                });
            });


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Activar Swagger en el entorno de desarrollo
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rigo Rigo Tienda API v1");
                    c.RoutePrefix = string.Empty;  
                });

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                Console.WriteLine("Controladores mapeados correctamente.");

            });
        }
    }
}
