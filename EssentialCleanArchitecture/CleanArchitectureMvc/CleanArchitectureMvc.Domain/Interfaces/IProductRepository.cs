using CleanArchitectureMvc.Domain.Entities;

namespace CleanArchitectureMvc.Domain.Interfaces
{
    /// <summary>
    /// Defines the contract for a repository that manages <see cref="Product"/> entities.
    /// </summary>
    /// <remarks>
    /// This interface provides methods for performing CRUD operations and querying <see cref="Product"/> entities.
    /// It serves as an abstraction for data access, enabling the implementation of the repository pattern.
    /// </remarks>
    public interface IProductRepository
    {
        /// <summary>
        /// Asynchronously retrieves all <see cref="Product"/> entities from the repository.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an <see cref="IEnumerable{T}"/> of <see cref="Product"/> entities.
        /// </returns>
        /// <remarks>
        /// This method is used to fetch all products stored in the repository. It is typically utilized in scenarios where a complete list of products is required.
        /// </remarks>
        Task<IEnumerable<Product>> GetAllAsync();

        /// <summary>
        /// Asynchronously retrieves a <see cref="Product"/> entity by its unique identifier.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="Product"/> to retrieve.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the <see cref="Product"/> entity with the specified identifier, or <c>null</c> if no such entity exists.
        /// </returns>
        /// <remarks>
        /// This method is used to fetch a single product from the repository based on its unique identifier.
        /// It is typically utilized in scenarios where detailed information about a specific product is required.
        /// </remarks>
        Task<Product?> GetByIdAsync(int id);

        /// <summary>
        /// Asynchronously retrieves a <see cref="Product"/> entity by its name.
        /// </summary>
        /// <param name="name">
        /// The name of the <see cref="Product"/> to retrieve.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the <see cref="Product"/> entity with the specified name, or <c>null</c> if no such entity exists.
        /// </returns>
        /// <remarks>
        /// This method is used to fetch a single product from the repository based on its name.
        /// It is typically utilized in scenarios where a product needs to be identified or accessed by its name.
        /// </remarks>
        Task<IEnumerable<Product>> GetByNameAsync(string name);

        /// <summary>
        /// Asynchronously retrieves all <see cref="Product"/> entities from the repository that match the specified price.
        /// </summary>
        /// <param name="price">
        /// The price value to filter the <see cref="Product"/> entities.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains an <see cref="IEnumerable{T}"/> of <see cref="Product"/> entities that have the specified price.
        /// </returns>
        /// <remarks>
        /// This method is used to query products based on their price.
        /// It is typically utilized in scenarios where products with a specific price need to be retrieved from the repository.
        /// </remarks>
        Task<IEnumerable<Product>> GetByPriceAsync(decimal price);

        /// <summary>
        /// Asynchronously retrieves a <see cref="Product"/> entity by its associated category identifier.
        /// </summary>
        /// <param name="categoryId">
        /// The unique identifier of the category whose associated <see cref="Product"/> is to be retrieved.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the <see cref="Product"/> entity associated with the specified category identifier, or <c>null</c> if no such entity exists.
        /// </returns>
        /// <remarks>
        /// This method is used to fetch a product based on its association with a specific category.
        /// It is typically utilized in scenarios where products need to be filtered by their category.
        /// </remarks>
        Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);

        /// <summary>
        /// Asynchronously retrieves a collection of <see cref="Product"/> entities that belong to a specified category.
        /// </summary>
        /// <param name="categoryName">
        /// The name of the category for which to retrieve the associated <see cref="Product"/> entities.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains an <see cref="IEnumerable{T}"/> of <see cref="Product"/> entities that are associated with the specified category.
        /// </returns>
        /// <remarks>
        /// This method is used to fetch products that belong to a specific category by its name.
        /// It is useful in scenarios where filtering products by category is required, such as displaying products in a specific category on a user interface.
        /// </remarks>
        Task<IEnumerable<Product>> GetByCategoryNameAsync(string categoryName);

        /// <summary>
        /// Asynchronously creates a new <see cref="Product"/> entity in the repository.
        /// </summary>
        /// <param name="product">
        /// The <see cref="Product"/> entity to be created. This parameter must not be <c>null</c>.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the created <see cref="Product"/> entity, 
        /// including any updates made during the creation process (e.g., generated identifiers).
        /// </returns>
        /// <remarks>
        /// This method is used to add a new product to the repository. It ensures that the product is persisted and available for subsequent operations.
        /// </remarks>
        Task<Product> CreateAsync(Product product);

        /// <summary>
        /// Asynchronously updates an existing <see cref="Product"/> entity in the repository.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> instance containing the updated data.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated <see cref="Product"/> entity.</returns>
        /// <remarks>
        /// This method is used to modify an existing product within the repository by replacing its data with the provided <see cref="Product"/> instance.
        /// It is typically utilized in scenarios where product details need to be revised.
        /// </remarks>
        Task<Product> UpdateAsync(Product product);

        /// <summary>
        /// Asynchronously deletes a <see cref="Product"/> entity with the specified unique identifier from the repository.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the <see cref="Product"/> to delete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the deleted <see cref="Product"/> entity, or <c>null</c> if no such entity exists.
        /// </returns>
        /// <remarks>
        /// This method is used to remove a product from the repository based on its unique identifier.
        /// It is typically utilized in scenarios where a product needs to be permanently deleted.
        /// </remarks>
        Task<Product?> DeleteAsync(int id);
    }
}