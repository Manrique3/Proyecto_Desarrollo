using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using ProyectoDesarrolloSoftware.AccesoDatos.DAOs;
using ProyectoDesarrolloSoftware.DataBase;
using ProyectoDesarrolloSoftware.Exceptions;
using ProyectoDesarrolloSoftware.Controllers;
using ProyectoDesarrolloSoftware.DataBase.DAOs.Implementations;

namespace ProyectoDesarrolloSoftware
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

            services.AddDbContext<DSDBContext>(options =>
            options.UseNpgsql(Configuration["DBConnectionString"], x => x.UseNetTopologySuite()));
            
            services.AddTransient<DSDBContext>();
            services.AddTransient<IPiezasDAO,PiezasDAO>();
            services.AddTransient<IProveedoresDAO, ProveedoresDAO>();
            services.AddTransient<IPieza_ProveedorDAO, Pieza_ProveedorDAO>();

            services.AddTransient<IAseguradoDAO,AseguradoDAO>();
            services.AddTransient<IPolizaDAO, PolizaDAO>();
            services.AddTransient<ICotizacionDAO, CotizacionDAO>();
            services.AddTransient<ICotizacion_TallerDAO, Cotizacion_TallerDAO>();


            // services.AddSingleton<IMarcaDAO, MockMarcaData>(); //Realizacion del Mock de Data. //Error al hacer simulación de los objetos en DTOs

            services.AddScoped<IMarcaDAO, MarcaDAO>();
            services.AddScoped<ITallerDAO, TallerDAO>();
            services.AddTransient<IIncidenteDAO, IncidenteDAO>();
            services.AddTransient<IIncidente_PiezaDAO, Incidente_PiezaDAO>();
            services.AddTransient<ITaller_MarcaDAO, Taller_MarcaDAO>();
            services.AddTransient<IPedidoDAO, PedidoDAO>();
            services.AddTransient<IProveedor_MarcaDAO, Proveedor_MarcaDAO>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProyectoDesarrolloSoftware", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProyectoDesarrolloSoftware v1"));
            }

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
