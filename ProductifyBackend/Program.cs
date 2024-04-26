using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using ProductifyBackend;
using ProductifyBackend.Extensions;


var builder = WebApplication.CreateBuilder(args);           // this line creates builder variable of type webApplicationBuilder

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));


// Add services to the container.
builder.Services.ConfigureCores();
builder.Services.ConfigureIISIntegration();
builder.Services.AddControllers();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);


builder.Services.AddControllers().AddApplicationPart(typeof(ProductifyBackend.Presentation.AssemblyReference).Assembly);


builder.Services.AddControllers();


// Build method builds the WebApplication and registers all the services added with IOC
var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else 
    app.UseHsts();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
