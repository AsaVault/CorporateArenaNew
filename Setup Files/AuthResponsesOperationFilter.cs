using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateArena.Presentation.Core.SetupFiles
{
    public class AuthResponsesOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var authAttributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
            .Union(context.MethodInfo.GetCustomAttributes(true))
            .OfType<AuthorizeAttribute>();

            if (authAttributes.Any())
            {
                var securityRequirement = new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                            Id = "Bearer", //The name of the previously defined security scheme.
                            Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                };
                operation.Security = new List<OpenApiSecurityRequirement> { securityRequirement };
                operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });
            }
        }
    }
}
