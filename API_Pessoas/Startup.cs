using System;
using System.Collections.Generic;
using API_Pessoas.Business;
using API_Pessoas.Business.Implementations;
using API_Pessoas.HyperMedia.Enricher;
using API_Pessoas.HyperMedia.Filters;
using API_Pessoas.Model.Context;
using API_Pessoas.Repository;
using API_Pessoas.Repository.Generics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Serilog;

namespace API_Pessoas
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment {get;}
        
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Adicionando DbContext
            var connection = Configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));
            
            if (Environment.IsDevelopment())
            {
                MigrateDatabase(connection);
            }

            
            //Aceitar serviços XML
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
                
            }).AddXmlSerializerFormatters();

            var filterOptions = new HypermediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());

            services.AddSingleton(filterOptions);
            
            //Adicionando servico para gerenciamento de vers�es da minha API
            services.AddApiVersioning();

            //Injections
            services.AddScoped<IPessoaBusiness, PessoaBusinessImplementation>();
            services.AddScoped<ILivroBusiness, LivroBusinessImplementation>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
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
                endpoints.MapControllerRoute("DefaultApi", "{controller=Values}/{id?}");
            });
        }

        private void MigrateDatabase(string connection)
        {
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations =  new List<string>
                    {
                        "db/migrations",
                        "db/dataset",
                    },
                    IsEraseDisabled =  true,
                };
                
                evolve.Migrate();

            }
            catch (Exception ex)
            {
                Log.Error("Database migration failed", ex);
                throw;
            }
        }
        
    }
}
