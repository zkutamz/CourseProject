using LMS.API.Options;
using LMS.API.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace LMS.API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
               IConfiguration configuration)
        {
            /*
             Don't use IOptions<TOptions> or
             IOptionsMonitor<TOptions> in Startup.ConfigureServices.
             An inconsistent options state may exist 
            due to the ordering of service registrations.
            */

            var swaggerOptions = configuration
                .GetSection(SwaggerOptions.Swagger)
                .Get<SwaggerOptions>();
            var swaggerSecurityDefinitionOptions = configuration
                .GetSection(SwaggerSecurityDefinitionOptions.SwaggerSecurityDefinition)
                .Get<SwaggerSecurityDefinitionOptions>();
            var swaggerSecurityRequirementOptions = configuration
                .GetSection(SwaggerSecurityRequirementOptions.SwaggerSecurityRequirement)
                .Get<SwaggerSecurityRequirementOptions>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swaggerOptions.VersionOne, new OpenApiInfo { Title = swaggerOptions.Title, Version = swaggerOptions.VersionOne });

                c.AddSecurityDefinition(swaggerSecurityDefinitionOptions.SecurityDefinitionName, new OpenApiSecurityScheme
                {
                    Description = swaggerSecurityDefinitionOptions.Description,
                    Name = swaggerSecurityDefinitionOptions.SecuritySchemaName,
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = swaggerSecurityDefinitionOptions.Schema
                });

                c.OperationFilter<AddAuthorizationHeaderOperationHeader>();

                /*
                 * Add xml comments to swagger UI
                 */
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            string issuer = configuration.GetValue<string>("Tokens:Issuer");
            string signingKey = configuration.GetValue<string>("Tokens:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
            });
            return services;

        }
    }
}
