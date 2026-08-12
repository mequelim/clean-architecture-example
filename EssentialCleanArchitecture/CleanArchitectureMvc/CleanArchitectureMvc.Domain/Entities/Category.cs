using CleanArchitectureMvc.Domain.Validations;

namespace CleanArchitectureMvc.Domain.Entities
{
    /// <summary>
    /// Represents a category entity in the domain layer of the application.
    /// </summary>
    /// <remarks>
    /// The <see cref="Category"/> class encapsulates the properties and behaviors of a category, including its name, description, and its association with its products.
    /// It inherits from the <see cref="EntityBase"/> class, which provides a unique identifier.
    /// </remarks>
    public sealed class Category : EntityBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class with the specified name and description.
        /// </summary>
        /// <param name="name">The name of the category.</param>
        /// <param name="description">The description of the category.</param>
        public Category(string name, string description) => ValidateDomain(name, description);

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class with the specified identifier, name, and description.
        /// </summary>
        /// <param name="id">The unique identifier for the category.</param>
        /// <param name="name">The name of the category.</param>
        /// <param name="description">The description of the category.</param>
        public Category(int id, string name, string description)
        {
            ValidateDomain(name, description);
            DomainExceptionValidation.When((id <= 0), "Id must be greater than zero!");

            Id = id;
        }

        /// <summary>
        /// Gets the collection of products associated with this category.
        /// </summary>
        /// <remarks>
        /// This property represents the relationship between a category and its associated products.
        /// Each product in the collection belongs to this category.
        /// </remarks>
        public ICollection<Product>? Products { get; set; }

        //* Methods...
        /// <summary>
        /// Validates the domain rules for the <see cref="Category"/> entity.
        /// </summary>
        /// <param name="name">The name of the category. Must be non-empty, at least 5 characters long, and no more than 150 characters.</param>
        /// <param name="description">The description of the category. Must be non-empty, at least 5 characters long, and no more than 300 characters.</param>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when any of the validation rules are violated, such as:
        /// <list type="bullet">
        /// <item><description><paramref name="name"/> is null, empty, too short, or too long.</description></item>
        /// <item><description><paramref name="description"/> is null, empty, too short, or too long.</description></item>
        /// </list>
        /// </exception>
        private void ValidateDomain(string name, string description)
        {
            // Name validations...
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required!");
            DomainExceptionValidation.When((name.Length < 5), "Name must be at least 5 characters long!");
            DomainExceptionValidation.When((name.Length > 150), "Name cannot exceed 150 characters!");

            // Description validations...
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required!");
            DomainExceptionValidation.When((description.Length < 5), "Description must be at least 5 characters long!");
            DomainExceptionValidation.When((description.Length > 300), "Description cannot exceed 300 characters!");

            Name = name;
            Description = description;
        }

        /// <summary>
        /// Updates the name and description of the category.
        /// </summary>
        /// <param name="name">The new name of the category. Must be non-empty, at least 5 characters long, and no more than 150 characters.</param>
        /// <param name="description">The new description of the category. Must be non-empty, at least 5 characters long, and no more than 300 characters.</param>
        /// <exception cref="DomainExceptionValidation">
        /// Thrown when any of the validation rules are violated, such as:
        /// <list type="bullet">
        /// <item><description><paramref name="name"/> is null, empty, too short, or too long.</description></item>
        /// <item><description><paramref name="description"/> is null, empty, too short, or too long.</description></item>
        /// </list>
        /// </exception>
        public void UpdateData(string name, string description) => ValidateDomain(name, description);
    }
}