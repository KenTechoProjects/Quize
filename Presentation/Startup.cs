using System;
using Application.Common.Behaviours;
using Application.Extensions;
using Application.Extentions;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.Filters;
using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;

namespace Presentation
{
    public class Startup
    {

        public Startup(IHostEnvironment hostingEnvironment)
        {



            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", reloadOnChange: true, optional: true)
                .AddEnvironmentVariables();


            Configuration = builder.Build();

            var elasticUri = Configuration["ElasticConfiguration:Uri"];

            var logFile ="SingleBiller-Log-";
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext().Enrich.WithExceptionDetails().Enrich.WithMachineName().WriteTo.File($"../logs/{logFile}", rollingInterval: RollingInterval.Hour).WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
                {

                    AutoRegisterTemplate = true,
                    IndexFormat = "singlebillerservice-{0:yyyy.MM.dd}"
                })
            .CreateLogger();
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCqrs();
            services.AddApplication();
            services.AddSwagger();
            services.AddJwtAuthentication(Configuration);

        

            services.AddControllers(options => options.Filters.Add(new ApiExceptionFilter()))
                 .AddNewtonsoftJson()
                .AddFluentValidation(fv =>
                {
                    //fv.RegisterValidatorsFromAssemblyContaining<CreateMessagePreferenceCommandValidator>();
                });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
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
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("../swagger/v1/swagger.json", "Single-Biller V1"); });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
