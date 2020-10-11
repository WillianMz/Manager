using Manager.Domain.Core.Comandos.Categorias;
using Manager.Domain.Interfaces;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Infra.Data.Context;
using Manager.Infra.Data.Repositorios;
using Manager.Infra.Data.Transacoes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace Manager.API
{
    public static class Setup
    {
        public static void ConfigureMediatR(this IServiceCollection services)
        {
           services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly, typeof(NovaCategoriaRequest).GetTypeInfo().Assembly);
           services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly, typeof(EditarCategoriaRequest).GetTypeInfo().Assembly);
        }

        public static void ConfigureRepositorios(this IServiceCollection services)
        {
            services.AddScoped<ManagerContext, ManagerContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepositorioCategoria, RepositorioCategoria>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ManagerTickets",
                    Description = "Teste de descrição",
                    TermsOfService = new Uri("https://managertickets.com.br/termos"),
                    Contact = new OpenApiContact
                    {
                        Name = "Willian",
                        Email = "willianmazzorana@hotmail.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termos de licença",
                        Url = new Uri("https://managertickets.com.br/licenca")
                    }
                });
            });
        }

        public static void ConfigureMVC(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;

            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }
    }
}
