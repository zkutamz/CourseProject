using LMS.API.Extensions;
using LMS.API.Filters;
using LMS.API.Middlewares;
using LMS.Model.AutoMapper;
using LMS.Repository.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace LMS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<IdentityOptions>(options => {
                // Default Lockout settings
                options.Lockout.AllowedForNewUsers = false;
            });
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllers(options =>
            {
                options.Filters.Add<ValidateIdParameterAttribute>();
            });

            services.ConfigureCors();
            services.ConfigureIdentity();
            services.ConfigureApplicationContext(Configuration);
            // services.ConfigureJwt(Configuration);
            services.AddHttpContextAccessor();
            services.ConfigureServices(Configuration);
            services.AddAutoMapper(typeof(MapperConfig)); //automapper
            services.AddIdentityServices(Configuration); //Swagger
            services.AddMvc()
                .AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.ConfigureOptionsPattern(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSerilogRequestLogging();

            app.UseRouting();
            app.UseCors("_myAllowSpecificOrigins");
            // Add Static Files Middleware  
            app.UseStaticFiles();
            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger LMS V1");
            });
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
