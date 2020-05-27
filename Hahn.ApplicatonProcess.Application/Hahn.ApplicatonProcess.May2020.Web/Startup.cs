using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aurelia.DotNet;
using Hahn.ApplicatonProcess.May2020.Data.Infrastructure;
using Hahn.ApplicatonProcess.May2020.Domain;
using Hahn.ApplicatonProcess.May2020.Infrastructure;
using Hahn.ApplicatonProcess.May2020.Web.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Hahn.ApplicatonProcess.May2020.Web
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
      services.ConfigureSwagger()
          .ConfigureSwaggerExamples()
          .ConfigureApplicantContext()
          .ConfigureLogging(Configuration)
          .ConfigureSerilog(Configuration)
          .ConfigureAutomapper()
          .ConfigureBusinessServices()
          .ConfigureMvc()
          .ConfigureFluentValidation()
          ;

      services.ConfigureCountriesApiHttpClient(Configuration.GetSection("CountriesApi"));
      // In production, the Aurelia files will be served from this directory
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "wwwroot/dist";
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      var logger =
          new LoggerConfiguration()
              .ReadFrom.Configuration(Configuration, "Serilog")
              .CreateLogger();
      loggerFactory.AddSerilog(logger);

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      if (!env.IsDevelopment())
      {
        app.UseSpaStaticFiles();
      }

      app.UseSerilogRequestLogging();

      app.UseRouting();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller}/{action=Index}/{id?}");
        // endpoints.MapControllerRoute(
        //   name: "spa-fallback",
        //   pattern: "{controller=Home}/{action=Index}");
      });

      app.UseSwagger()
        .UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
      app.UseSpa(spa => {
        spa.Options.SourcePath = ".";

        if (env.IsDevelopment())
        {
          spa.UseAureliaCliServer(); // Optional HMR (Hot Module Reload)
        }
      });
    }
  }
}
