using LMS.API.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace LMS.API.Utilities
{
    public class AddAuthorizationHeaderOperationHeader : IOperationFilter
    {
        private readonly SwaggerSecurityRequirementOptions _swaggerSecurityRequirementOptions;

        public AddAuthorizationHeaderOperationHeader(IOptions<SwaggerSecurityRequirementOptions> swaggerSecurityRequirementOptions)
        {
            _swaggerSecurityRequirementOptions = swaggerSecurityRequirementOptions.Value;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var actionMetadata = context.ApiDescription.ActionDescriptor.EndpointMetadata;
            var isAuthorized = actionMetadata.Any(metadataItem => metadataItem is AuthorizeAttribute);
            var allowAnonymous = actionMetadata.Any(metadataItem => metadataItem is AllowAnonymousAttribute);

            if (!isAuthorized || allowAnonymous)
            {
                return;
            }
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Security = new List<OpenApiSecurityRequirement>();

            //Add JWT bearer type
            operation.Security.Add(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = _swaggerSecurityRequirementOptions.Id
                        },
                        Scheme = _swaggerSecurityRequirementOptions.Scheme,
                        Name = _swaggerSecurityRequirementOptions.Name,
                        In = ParameterLocation.Header,
                    }, new List<string>()
                }
            });
        }
    }
}