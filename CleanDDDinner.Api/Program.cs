using CleanDDDinner.Api;
using CleanDDDinner.Api.Endpoints;
using CleanDDDinner.Application;
using CleanDDDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

var app = builder.Build();

app.UseExceptionHandler("/error");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapErrorEndpoints();
app.MapAuthenticationEndpoints();

app.Run();
