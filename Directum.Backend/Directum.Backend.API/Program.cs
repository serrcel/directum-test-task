using Directum.Backend.Infrastructure.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Привет! Перейдите на /swagger чтобы увидеть потыкать что-нибудь.");

await app.RunAsync();

namespace Directum.Backend.API
{
    /// <summary>
    /// Make the implicit Program class public so test projects can access it.
    /// </summary>
    // ReSharper disable once UnusedType.Global
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class Program { }
}
