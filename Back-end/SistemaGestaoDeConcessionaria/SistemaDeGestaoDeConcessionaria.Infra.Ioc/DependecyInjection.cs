using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaDeGestaoDeConcessionaria.Application.Interfaces;
using SistemaDeGestaoDeConcessionaria.Application.Services;
using SistemaDeGestaoDeConcessionaria.Infra.Data.Context;
using SistemaDeGestaoDeConcessionaria.Infra.Data.Repositorys;
using SistemaGestaoDeConcessionaria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDeGestaoDeConcessionaria.Infra.Ioc
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySQL(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
                  
            });

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAutomovelRepository, AutomovelRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IAutomovelService, AutomovelService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IVendaService, VendaService>();

            return services;

            
        }
    }
}
