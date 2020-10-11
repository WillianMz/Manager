using Manager.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Manager.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            //passa para a configuracao qual o arquivo com dados de acesso a base de dados
            var builder = new ConfigurationBuilder().AddJsonFile("Config.json");
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //passa a string de conexao
            var conexao = Configuration.GetConnectionString("ManagerDB");
            //adiciona o contexto
            //informa o tipo de lazyloading que esta sendo usado
            //informa em qual projeto esta o EFCore
            services.AddDbContext<ManagerContext>(opt => opt.UseLazyLoadingProxies().UseMySql(conexao, m => m.MigrationsAssembly("Manager.Infra.Data")));

            services.AddMvcCore();
            services.ConfigureMediatR();
            services.ConfigureRepositorios();
            services.ConfigureSwagger();
            services.ConfigureMVC();
            services.AddHttpContextAccessor();

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;

            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //permite requisições usando Header, Metodos e Origem(Qualquer site)
            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            app.UseMvc();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ManagerTickets - v1");
            });
        }
    }
}
