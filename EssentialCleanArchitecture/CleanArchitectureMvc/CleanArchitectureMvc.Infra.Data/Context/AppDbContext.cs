using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureMvc.Infra.Data.Context
{
    /// <summary>
    /// Represents the Entity Framework Core database context for the application.
    /// </summary>
    /// <remarks>
    /// This class extends <see cref="IdentityDbContext{TUser}"/> to integrate ASP.NET Core Identity functionality with the application's database.
    /// It provides DbSet properties for managing <see cref="Category"/> and <see cref="Product"/> entities and includes configuration logic for entity relationships and mappings.
    /// </remarks>
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Represents the database context for interacting with the application's database.
        /// Provides the EF Core integration for managing <see cref="Category"/> and <see cref="Product"/> entity sets.
        /// </summary>
        private AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Gets or sets the collection of categories in the database.
        /// </summary>
        /// <remarks>
        /// This property represents a DbSet of <see cref="Category"/> objects, providing access to the categories stored in the database.
        /// It enables querying, addition, deletion, and updating of category data.
        /// </remarks>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the collection of products in the database.
        /// </summary>
        /// <remarks>
        /// This property represents a DbSet of <see cref="Product"/> objects, allowing access to the products stored in the database.
        /// It facilitates querying, addition, deletion, and updating of product data.
        /// </remarks>
        public DbSet<Product> Products { get; set; }

        //* Methods...
        /// <summary>
        /// Configures the model relationships, constraints, and additional mapping settings for the application using EF Core.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="ModelBuilder"/> instance used to configure the database schema and model mappings.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}