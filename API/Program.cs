using API.Middleware;
using Application.Activities.Commands;
using Application.Activities.Queries;
using Application.Activities.Validators;
using Application.Core;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssemblyContaining<GetActivityList.Handler>();
    x.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CreateActivity.Handler).Assembly));
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<CreateActivityValidator>();
builder.Services.AddTransient<ExceptionMiddleware>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.UseCors(x =>
{
    x.AllowAnyHeader();
    x.AllowAnyMethod();
    x.AllowAnyOrigin();
    x.WithOrigins("http://localhost:3000", "https://localhost:3000");
});

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync();
    await DbInitializer.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Ocorreu um erro durante a migração.");
    throw;
}

app.Run();
