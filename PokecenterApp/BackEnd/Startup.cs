using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using BackEnd.Data.ElasticSearch;
using BackEnd.Services;
using BackEnd.Data;

namespace BackEnd
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

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cole's Pokedex API", Version = "v1" });
            });

            // Register ElasticSearch Client for Dependency Injection here.
            services.AddOptions();
            services.Configure<ElasticConnectionSettings>(Configuration.GetSection("ElasticConnectionSettings"));
            services.AddSingleton(typeof(ElasticClientProvider));
            // Register ElasticSearch Async Handler here.
            services.AddSingleton(typeof(AsyncElasticSearchHandler));
            // Register Pokemon Service here.
            services.AddSingleton(typeof(PokemonService));
            services.AddSingleton(typeof(ElasticSearchToModelMapper));
            //Register Database Access here.
            services.AddSingleton(typeof(DatabaseAccess));

            services.AddCors(o => o.AddPolicy("LocalhostPLEASEWORKPLEASE", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            //More on Swagger from:
            //https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started
            //-with-swashbuckle?view=aspnetcore-3.0&tabs=visual-studio 
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cole's Pokedex API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //This was a fun one... a few hours later figured out
            //I needed this to actually let my localhosts talk. -_-
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            loggerFactory.AddFile("Logs/pokedexApp-{Date}.txt");
        }
    }
}
