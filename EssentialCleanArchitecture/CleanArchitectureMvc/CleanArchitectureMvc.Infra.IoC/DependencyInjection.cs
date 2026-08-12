using CleanArchitectureMvc.Application.Interfaces;
using CleanArchitectureMvc.Application.Mappings;
using CleanArchitectureMvc.Application.Services;
using CleanArchitectureMvc.Domain.Account;
using CleanArchitectureMvc.Domain.Interfaces;
using CleanArchitectureMvc.Infra.Data.Context;
using CleanArchitectureMvc.Infra.Data.Identity;
using CleanArchitectureMvc.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureMvc.Infra.IoC
{
    /// <summary>
    /// Provides extension methods for configuring dependency injection in the application.
    /// </summary>
    public static class DependencyInjection
    {
        //* Methods...
        /// <summary>
        /// Configures and registers the infrastructure services for the application, including database context,
        /// repositories, and application services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to which the services will be added.</param>
        /// <param name="configuration">The <see cref="IConfiguration"/> instance used to retrieve configuration settings.</param>
        /// <returns>The updated <see cref="IServiceCollection"/> with the registered services.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //* Registering database context...
            services.AddDbContext<AppDbContext>((options) =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    (sqlOptions) => sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                )
            );

            //* Registering AutoMapper...
            services.AddAutoMapper((config) => config.AddProfile<DomainToDtoMappingProfile>());
            //tip: if you want to add the type of the profile directly, you can use: `services.AddAutoMapper((config) => config.AddProfile<DomainToDTOMappingProfile>(), typeof(DomainToDTOMappingProfile).Assembly);`!

            // * Registering Identity...
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            //* Registering repositories...
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            //* Registering services...
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            //* Registering Identity services...
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            //* Configuring application cookie...
            services.ConfigureApplicationCookie((options) => options.AccessDeniedPath = "/Account/Path");

            //* Configuring Handlers...
            //services.AddMediatR((config) => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddMediatR((config) => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.Load("CleanArchitectureMvc.Application")));

            return services;
        }
    }
}