using API_Pessoas.Business;
using API_Pessoas.Business.Implementations;
using API_Pessoas.Model.Context;
using API_Pessoas.Repository;
using API_Pessoas.Repository.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API_Pessoas
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

            //Adicionando DbContext
            var connection = Configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<IPersonRepository>(options => options.UseMySql(connection));

            //Adicionando servico para gerenciamento de versões da minha API
            services.AddApiVersioning();

            //Injections
            services.AddScoped<IPessoaBusiness, PessoaBusinessImplementation>();
            services.AddScoped<IPessoaRepository, PessoaRepositoryImplementation>();

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
