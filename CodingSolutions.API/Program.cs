using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using CodingSolutions.API.Swagger;
using CodingSolutions.DataAccess.Registering;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(opt =>
{
    opt.EnableJWTBearerAuth = false;
    opt.ShortSchemaNames = true;
    opt.RemoveEmptyRequestSchema = true;
    opt.DocumentSettings = ds =>
    {
        ds.DocumentProcessors.Add(new CodingSolutionsSwaggerDocumentSettings());
    };
});

var connectionString = config.GetConnectionString("DefaultConnection");
builder.Services.AddDataAccess(connectionString);
builder.Services.AddCors(x =>
{
    var policy = new CorsPolicyBuilder()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
    .Build();
    x.AddDefaultPolicy(policy);
    x.AddPolicy("AllowAll", policy);
});

var app = builder.Build();
app.UseCors();
app.UseFastEndpoints(options =>
{
    options.Endpoints.RoutePrefix = "api";
    options.Endpoints.Configurator = ep =>
    {
        ep.AllowAnonymous();
    };
});
// Configure the HTTP request pipeline.
app.UseSwaggerGen();

app.UseHttpsRedirection();

app.Run();