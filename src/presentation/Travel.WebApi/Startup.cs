//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.Extensions.Logging;
//using Microsoft.OpenApi.Models;
//using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
//using Travel.Data.Contexts;
//using Travel.Application.Common.Interfaces;
//using Travel.Identity.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using Travel.Application;
using Travel.Data;
using Travel.Identity;
using Travel.Identity.Helpers;
using Travel.Shared;
using Travel.WebApi.Filters;
using Travel.WebApi.Helpers;
using Travel.WebApi.Extensions;
using Microsoft.AspNetCore.SpaServices;
using VueCliMiddleware;

namespace Travel.WebApi
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
            //services.AddDbContext<TravelDbContext>(optioons =>
            //optioons.UseSqlite("Data Source=TravelTourDatabase.sqlite3"));
            services.AddApplication(Configuration);
            services.AddInfrastructureData(Configuration);
            services.AddInfrastructureShared(Configuration);
            services.AddInfrastructureIdentity(Configuration);

            services.AddHttpContextAccessor();

            services.AddControllers();

            services.AddControllersWithViews(options => 
            options.Filters.Add(new ApiExceptionFilter()));
            services.Configure<ApiBehaviorOptions>(options => 
            options.SuppressModelStateInvalidFilter = true);

            services.AddApiVersioningExtension();
            services.AddVersionedApiExplorerExtension();
            services.AddSwaggerGenExtension();
            //services.AddSwaggerGen(c =>
            //{
            //    //c.SwaggerDoc("v1", new OpenApiInfo { Title = "Travel.WebApi", Version = "v1" });
            //    c.OperationFilter<SwaggerDefaultValues>();

            //    //allow to enter JWT in Sawgger request
            //    //describ how API is protected
            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        Description = "JWT Authorization header using the Bearer scheme.",
            //        Name = "Authorization",
            //        In = ParameterLocation.Header,
            //        Type = SecuritySchemeType.Http,
            //        Scheme = "bearer"
            //    });

            //    //add global security requirement
            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //        {
            //            Reference=new OpenApiReference
            //            {
            //                Type=ReferenceType.SecurityScheme,
            //                Id="Bearer"
            //            }
            //        },new List<string>() 
            //        }
            //    });
            //});

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            //services.AddApiVersioning(config =>
            //{
            //    config.DefaultApiVersion = new ApiVersion(1, 0);
            //    config.AssumeDefaultVersionWhenUnspecified = true;
            //    config.ReportApiVersions = true;
            //});

            //services.AddVersionedApiExplorer(options =>
            //{
            //    options.GroupNameFormat = "'v'VVV";
            //    options.SubstituteApiVersionInUrl = true;
            //});

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "../vue-app/dist";
            });

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerExtension(provider);
                //app.UseSwagger();
                //app.UseSwaggerUI(c =>
                ////c.SwaggerEndpoint("/swagger/v1/swagger.json", "Travel.WebApi v1")
                //{
                //    foreach (var description in provider.ApiVersionDescriptions)
                //    {
                //        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                //            description.GroupName.ToUpperInvariant());
                //    }
                //});
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();

            }
            app.UseCors(b =>
            {
                b.AllowAnyOrigin();
                b.AllowAnyHeader();
                b.AllowAnyMethod();
            });



            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<JwtMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "../vue-app";
                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }
            });
        }
    }
}
