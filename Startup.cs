using RestFul.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.EntityFrameworkCore;

namespace RestFul
{
    /*    public class Startup
        {
            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public IConfiguration Configuration { get; }

            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                services.AddControllersWithViews();
                // In production, the Angular files will be served from this directory
                services.AddSpaStaticFiles(configuration =>
                {
                    configuration.RootPath = "ClientApp/dist";
                });
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Error");
                }

                app.UseStaticFiles();
                if (!env.IsDevelopment())
                {
                    app.UseSpaStaticFiles();
                }

                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller}/{action=Index}/{id?}");
                });

                app.UseSpa(spa =>
                {
                    // To learn more about options for serving an Angular SPA from ASP.NET Core,
                    // see https://go.microsoft.com/fwlink/?linkid=864501

                    spa.Options.SourcePath = "ClientApp";

                    if (env.IsDevelopment())
                    {
                        spa.UseAngularCliServer(npmScript: "start");
                    }
                });
            }
        }*/
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {

/*                options.AddDefaultPolicy(
                    builder => {
                        builder.AllowAnyOrigin();
                    });*/
                options.AddDefaultPolicy(
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200")
                                                         .AllowAnyHeader()
                                                         .AllowAnyMethod();
                                  });

            });


            services.AddControllers();

            services.AddDbContext<CodingEventsDbContext>(o => o.UseSqlite("Data Source=sqlite.db;"));

            services.AddSwaggerGen(
              options => {
                  options.SwaggerDoc(
              "v1",
              new OpenApiInfo
                  {
                      Version = "v1",
                      Title = "Coding Events API",
                      Description = "REST API for managing Coding Events"
                  }
            );
              }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {


                endpoints.MapControllers();  //.RequireCors(MyAllowSpecificOrigins);
            });

            app.UseSwagger();
            app.UseSwaggerUI(
              options => {
                  options.RoutePrefix = ""; // root path of the server
            options.SwaggerEndpoint(
              "/swagger/v1/swagger.json",
              "Patrick's Coding Events API Documentation"
            );
              }
            );


            // app.UseCors(MyAllowSpecificOrigins);

            // run migrations on startup
            var dbContext = app.ApplicationServices.CreateScope()
              .ServiceProvider.GetService<CodingEventsDbContext>();
            dbContext.Database.Migrate();
        }


    }

}
