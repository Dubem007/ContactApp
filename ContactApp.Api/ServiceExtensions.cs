using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Api
{
    public static class ServiceExtensions
    {
        public static void ConfigureSwagger(this IServiceCollection services) { 
            services.AddSwaggerGen(c => { c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme { Name = "Authorization", Type = SecuritySchemeType.ApiKey, Scheme = "Bearer", BearerFormat = "JWT", In = ParameterLocation.Header, Description = "JWT Authorization header using the Bearer scheme." }); 
                c.AddSecurityRequirement(new OpenApiSecurityRequirement { { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, new string[] { } 
                    } 
                }); 
            });
        }
    }
}
