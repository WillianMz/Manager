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
        public IConfiguration Configuration { get; set;}

        public Startup(IConfiguration configuration)
        {
            //passa para a configuracao o arquivo de configuracao json com dados da connection string
            var builder = new ConfigurationBuilder().AddJsonFile("config.json");
            Configuration = builder.Build();

        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //passa a string de conexao
            var con = Configuration.GetConnectionString("ManagerDB");
            /*
                adiciona o contexto
                passa o LazyLoading que esta sendo usado
                informa o tipo de banco de dados = MySQL
                informa em qual projeto/solucao esta o EntityFrameworkCore = MigrationsAssembly
            */
            services.AddDbContext<ManagerContext>(opt => opt.UseLazyLoadingProxies().UseMySql(con, m => m.MigrationsAssembly("Manager.Infra.Data")));
            services.AddMvcCore();

            services.ConfigureMediatR();
            services.ConfigureRepositorios();
            services.ConfigureSwagger();
            services.ConfigureAuthentication();
            services.ConfigureMVC();
            services.AddHttpContextAccessor();

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;

            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Permite requisicoes usando Header, Methods e Origem(QUALQUER SITE)
            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseMvc();

            //cria a documentacao da API de forma automatica
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Manager - v1.0");
            });
        }
    }
}
