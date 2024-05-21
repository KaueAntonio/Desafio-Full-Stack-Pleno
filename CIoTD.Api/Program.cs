using CIoTD.Api.Docs;
using CIoTD.Api.Middlewares;
using CIoTD.Core.IoC;
using CIoTD.Infrastructure.IoC;

var builder = WebApplication.CreateBuilder(args);

CoreModules.AddCoreModules(builder.Services);
InfraModules.AddInfraModules(builder.Services);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

SwaggerDocs.AddSwaggerDocs(builder.Services);

var app = builder.Build();

app.MapGet("/", () => "Online");

app.MapControllers();

app.UseMiddleware<JwtMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
