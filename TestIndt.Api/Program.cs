using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestIndt.Application.Behaviors;
using TestIndt.Application.Commands.UsuarioModule.Handler;
using TestIndt.Application.Queries.UsuarioModule.Handler;
using TestIndt.Domain.Entities.Repositories;
using TestIndt.Domain.Services;
using TestIndt.Infra.Data.Context;
using TestIndt.Infra.Data.Repository;
using TestIndt.Infra.Data.Repositories;
using TestIndt.Application.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Test Indt",
        Version = "v1"
    });
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetUserByIdQueryHandler).Assembly));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAccountCodeSuggestionService, AccountCodeSuggestionService>();

builder.Services.AddScoped<IRouteRepository, RouteRepository>();

builder.Services.AddDbContext<DefaultDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddValidatorsFromAssemblyContaining<TestIndt.Application.Commands.UsuarioModule.Validations.CreateUserCommandValidator>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddAutoMapper(typeof(RouteProfile).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
