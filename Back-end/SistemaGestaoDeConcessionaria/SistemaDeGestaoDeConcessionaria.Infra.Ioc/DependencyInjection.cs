using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Microsoft.IdentityModel.Tokens;
using SistemaGestaoDeConcessionaria.Domain.Account;
using SistemaDeGestaoDeConcessionaria.Infra.Data.Identity;

namespace SistemaDeGestaoDeConcessionaria.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySQL(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
                  
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                    ClockSkew = TimeSpan.Zero,
                };
            });

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAutomovelRepository, AutomovelRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IAutomovelService, AutomovelService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();

            return services;

            
        }
    }
}
