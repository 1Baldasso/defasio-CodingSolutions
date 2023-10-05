using CodingSolutions.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CodingSolutions.DataAccess.Registering;

public static class DataAccessServiceCollectionExtension
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SolutionDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddSingleton<IClienteRepository, ClienteMockRepository>();
        services.AddSingleton<IProdutoRepository, ProdutoMockRepository>();
        return services;
    }
}