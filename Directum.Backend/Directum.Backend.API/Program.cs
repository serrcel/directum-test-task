using Directum.Backend.Infrastructure.Data;
using Directum.Backend.Infrastructure.DI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Applying migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await db.Database.MigrateAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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
