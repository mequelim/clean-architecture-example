namespace CleanArchitectureMvc.Domain.Entities
{
    /// <summary>
    /// Serves as the base class for all entities in the domain model.
    /// </summary>
    /// <remarks>
    /// The <see cref="EntityBase"/> class provides common properties and functionality shared across all domain entities, including a unique identifier, a name, and a description.
    /// It is designed to be inherited by specific entity classes.
    /// </remarks>
    public abstract class EntityBase
    {
        /// <summary>
        /// Gets the unique identifier for the category or for the product.
        /// </summary>
        /// <value>
        /// An integer representing the unique identifier of the category/product.
        /// </value>
        /// <remarks>
        /// The <see cref="Id"/> property is used as the primary key for the <see cref="Category"/>/<see cref="Product"/> entity.
        /// It ensures that each category/product can be uniquely identified within the system.
        /// </remarks>
        public int Id { get; protected set; }

        /// <summary>
        /// Gets the name of the category or of the product.
        /// </summary>
        /// <remarks>
        /// The <see cref="Name"/> property represents the name of the category/product, which is used to identify and describe the product within the domain.
        /// It is required property and must be unique within the context of the application.
        /// </remarks>
        public string? Name { get; protected set; }

        /// <summary>
        /// Gets the description of the category or of the product.
        /// </summary>
        /// <remarks>
        /// The description provides additional details about the category/product, such as its features, usage, or other relevant information.
        /// </remarks>
        public string? Description { get; protected set; }
    }
}