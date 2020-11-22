using Manager.Domain.Core.Comandos.Categorias;
using Manager.Domain.Core.Comandos.Projetos;
using Manager.Domain.Core.Comandos.Tickets;
using Manager.Domain.Interfaces;
using Manager.Domain.Interfaces.Repositorios;
using Manager.Domain.Interfaces.Servicos;
using Manager.Domain.Queries.Consultas.Categorias;
using Manager.Domain.Queries.Interfaces;
using Manager.Infra.Data.Context;
using Manager.Infra.Data.Repositorios;
using Manager.Infra.Data.Transacoes;
using Manager.Infra.Services.Email;
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
           services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly, typeof(CriarCategoria).GetTypeInfo().Assembly);
           services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly, typeof(EditarCategoria).GetTypeInfo().Assembly);
           services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly, typeof(CriarProjeto).GetTypeInfo().Assembly);
           services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly, typeof(CriarTicket).GetTypeInfo().Assembly);
           services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly, typeof(ListarCategorias).GetTypeInfo().Assembly);
        }

        //INJENCAO DE DEPENDENCIAS
        public static void ConfigureRepositorios(this IServiceCollection services)
        {
            services.AddScoped<ManagerContext, ManagerContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepositorioCategoria, RepositorioCategoria>();
            services.AddTransient<IRepositorioProjeto, RepositorioProjeto>();
            services.AddTransient<IRepositorioTicket, RepositorioTicket>();
            services.AddTransient<IRepositorioUsuario, RepositorioUsuario>();
            services.AddTransient<IRepositorioAnexo, RepositorioAnexo>();
            services.AddTransient<IRepositorioNota, RepositorioNota>();
            services.AddTransient<IRepositorioDocumento, RepositorioDocumento>();
            services.AddTransient<IRepositorioRelease, RepositorioRelease>();

            //consultas
            services.AddTransient<IConsultaCategoria, RepositorioCategoria>();
            services.AddTransient<IConsultaProjeto, RepositorioProjeto>();
            services.AddTransient<IConsultaTicket, RepositorioTicket>();
            services.AddTransient<IConsultaUsuario, RepositorioUsuario>();

            services.AddTransient<IServicoEmail, ServicoEmail>();
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
                    TermsOfService = new Uri("https://managertickets.com.br"),
                    Contact = new OpenApiContact
                    {
                        Name = "Willian",
                        Email = "willianmazzorana@hotmail.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termos de licença",
                        Url = new Uri("https://managertickets.com.br")
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
