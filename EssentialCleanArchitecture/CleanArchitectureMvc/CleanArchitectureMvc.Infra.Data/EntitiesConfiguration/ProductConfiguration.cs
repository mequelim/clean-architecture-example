using CleanArchitectureMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureMvc.Infra.Data.EntitiesConfiguration
{
    /// <summary>
    /// Configures the entity framework settings for the <see cref="Product"/> entity.
    /// </summary>
    /// <remarks>
    /// This class defines the entity configuration for the <see cref="Product"/> class, such as table mappings,
    /// relationships, property constraints, and any additional EF Core specifications required for persistence.
    /// Implements the <see cref="IEntityTypeConfiguration{T}"/> interface where T is <see cref="Product"/>.
    /// </remarks>
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /// <summary>
        /// Configures the entity framework model for the <see cref="Product"/> entity.
        /// </summary>
        /// <param name="builder">The builder used to configure the <see cref="Product"/> entity.</param>
        /// <exception cref="NotImplementedException">Thrown as this method has not been implemented yet.</exception>
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey((product) => product.Id);

            builder
                .Property((product) => product.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property((product) => product.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder
                .Property((product) => product.Price)
                .HasPrecision(10, 2)
                .IsRequired();

            builder
                .HasOne((product) => product.Category)
                .WithMany((category) => category.Products)
                .HasForeignKey((product) => product.CategoryId)
                .IsRequired();  // nullable == false
        }
    }
}