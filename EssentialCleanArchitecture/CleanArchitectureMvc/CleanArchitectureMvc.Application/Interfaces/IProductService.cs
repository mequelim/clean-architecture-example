using CleanArchitectureMvc.Application.DTOs;

namespace CleanArchitectureMvc.Application.Interfaces
{
    /// <summary>
    /// Defines the contract for a service that manages product-related operations in the application.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Asynchronously retrieves all products.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a collection of <see cref="ProductDto"/> objects representing the products.
        /// </returns>
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();

        /// <summary>
        /// Asynchronously retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to retrieve.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains the <see cref="ProductDto"/> representing the product with the specified identifier, or <c>null</c> if no product is found.
        /// </returns>
        Task<ProductDto> GetProductByIdAsync(int id);

        /// <summary>
        /// Retrieves a collection of products whose names match the specified search term.
        /// </summary>
        /// <param name="name">The name or partial name of the products to search for.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of <see cref="ProductDto"/> objects that match the specified name.</returns>
        Task<IEnumerable<ProductDto>> GetProductsByNameAsync(string name);

        /// <summary>
        /// Asynchronously retrieves products filtered by a specified price.
        /// </summary>
        /// <param name="price">The price used to filter the products.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a collection of <see cref="ProductDto"/> objects representing the products that match the price filter.
        /// </returns>
        Task<IEnumerable<ProductDto>> GetProductsByPriceAsync(decimal price);

        /// <summary>
        /// Asynchronously retrieves a collection of products associated with a specific category.
        /// </summary>
        /// <param name="categoryId">The unique identifier of the category whose products are to be retrieved.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of <see cref="ProductDto"/> objects.</returns>
        Task<IEnumerable<ProductDto>> GetProductsByCategoryIdAsync(int categoryId);

        /// <summary>
        /// Retrieves a collection of products that belong to the specified category.
        /// </summary>
        /// <param name="categoryName">The name of the category for which to retrieve products.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of <see cref="ProductDto"/> objects associated with the specified category.</returns>
        Task<IEnumerable<ProductDto>> GetProductsByCategoryNameAsync(string categoryName);

        /// <summary>
        /// Asynchronously creates a new product in the application.
        /// </summary>
        /// <param name="productDto">
        /// A <see cref="ProductDto"/> object containing the details of the product to be created.
        /// </param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task CreateProductAsync(ProductDto productDto);

        /// <summary>
        /// Updates an existing product asynchronously.
        /// </summary>
        /// <param name="productDto">
        /// A <see cref="ProductDto"/> object containing the updated product details.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> representing the asynchronous operation.
        /// </returns>
        Task UpdateProductAsync(ProductDto productDto);

        /// <summary>
        /// Asynchronously removes a product from the application by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to be removed.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task RemoveProductAsync(int id);
    }
}