using Manager.Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Manager.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //informa para a configuracao, qual é o arquivo de configuracao
            var builder = new ConfigurationBuilder().AddJsonFile("Config.json");
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //passa a string de conexao
            var conexao = Configuration.GetConnectionString("ManagerDB");
            /*
                Adiciona o contexto, passa a configuracao do lazyLoading que esta sendo usada
                Informa o banco de dados que esta sendo usado, neste caso o MySQL
                Informa em qual projeto esta o EFCore
            */
            services.AddDbContext<ManagerContext>(option => option.UseLazyLoadingProxies().UseMySql(conexao, m => m.MigrationsAssembly("Manager.Infra.Data")));
            services.AddMvcCore();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
