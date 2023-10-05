using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using CodingSolutions.API.Swagger;
using CodingSolutions.DataAccess.Registering;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var vaultClient = new SecretClient(
        new Uri(config["KeyVault"]),
        new DefaultAzureCredential(new DefaultAzureCredentialOptions
        {
            ManagedIdentityClientId = config["directoryId"]
        }));
var connectionString = vaultClient.GetSecret("desafioCSConnectionString").Value.Value;
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

builder.Services.AddDataAccess(connectionString);
builder.Services.AddCors(builder => builder.AddDefaultPolicy(policy => policy.AllowAnyOrigin()));

var app = builder.Build();
app.UseFastEndpoints(options =>
{
    options.Endpoints.RoutePrefix = "api";
    options.Endpoints.Configurator = ep =>
    {
        ep.AllowAnonymous();
        ep.Options(o => o.RequireCors(x => x.AllowAnyOrigin()));
    };
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
}

app.UseCors();
app.UseHttpsRedirection();

app.Run();