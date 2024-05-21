using Microsoft.OpenApi.Models;

namespace CIoTD.Api.Docs;

public static class SwaggerDocs
{
    public static void AddSwaggerDocs(IServiceCollection services)
    {
        services.AddSwaggerGen(swagger =>
        {
            swagger.SwaggerDoc("V1", new OpenApiInfo
            {
                Version = "V1",
                Title = "Community IoT Device (CIoTD)",
                Description = @"<p>A CIoTD é uma plataforma colaborativa para compartilhamento de acesso à dados
                                     de dispositivos IoT.</p>
                                     <p>Através dela, colaboradores podem cadastrar seus dispositivos, permitindo
                                     que qualquer pessoa possa coletar os dados desses dispositivos e utilizar em suas
                                     aplicações.</p>"
            });
        
            swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization Bearer.",
            });
            swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                      {
                          Reference = new OpenApiReference
                          {
                              Type = ReferenceType.SecurityScheme,
                              Id = "Bearer"
                          }
                      },
                    Array.Empty<string>()
                }
            });
        });
    }
}