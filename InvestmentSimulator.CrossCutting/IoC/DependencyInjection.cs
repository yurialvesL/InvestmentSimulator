using InvestmentSimulator.CrossCutting.Common.Interfaces;
using InvestmentSimulator.CrossCutting.Common.Security;
using InvestmentSimulator.Domain.Interfaces;
using InvestmentSimulator.Infrastructure.Context;
using InvestmentSimulator.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvestmentSimulator.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))       
            throw new ArgumentException("Connection string 'DefaultConnection' is not configured.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString));

        //Repositories
        services.AddScoped<IInvestmentRepository, InvestmentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();


        services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();


        // Register your DbContext, Repositories, and other services here
        // Example:
        // services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("YourConnectionString"));

        // services.AddScoped<IInvestmentRepository, InvestmentRepository>();
        // services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
