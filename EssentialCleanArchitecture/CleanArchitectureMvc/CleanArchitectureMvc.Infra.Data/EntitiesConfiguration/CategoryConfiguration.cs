using CleanArchitectureMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitectureMvc.Infra.Data.EntitiesConfiguration
{
    /// <summary>
    /// Configures the entity Category for use in the database context.
    /// </summary>
    /// <remarks>
    /// The <see cref="CategoryConfiguration"/> class is used to define the structure and
    /// constraints of the <see cref="Category"/> entity within the Entity Framework Core model.
    /// This includes primary keys, property constraints, and maximum lengths.
    /// </remarks>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        /// <summary>
        /// Configures the <see cref="Category"/> entity for the Entity Framework Core model.
        /// </summary>
        /// <param name="builder">An <see cref="EntityTypeBuilder{TEntity}"/> used to configure the <see cref="Category"/> entity.</param>
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey((category) => category.Id);

            builder
                .Property((category) => category.Name)
                .HasMaxLength(150)
                .IsRequired();  // nullable == false

            builder
                .Property((category) => category.Description)
                .HasMaxLength(300)
                .IsRequired();  // nullable == false
        }
    }
}