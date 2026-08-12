using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;
using CleanArchitectureMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureMvc.Infra.Data.Repositories
{
    /// <summary>
    /// Implements the repository pattern for managing <see cref="Product"/> entities within a data store.
    /// </summary>
    /// <remarks>
    /// The <see cref="ProductRepository"/> class provides concrete implementations of the methods defined in the <see cref="IProductRepository"/> interface.
    /// It handles operations such as fetching, creating, updating, and deleting <see cref="Product"/> entities.
    /// </remarks>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Represents the application database context used for interacting with the data store.
        /// </summary>
        /// <remarks>
        /// The <c>_context</c> field is a private instance of <see cref="AppDbContext"/> that facilitates database operations such as querying and persisting data.
        /// It serves as the primary means for accessing and managing the application's database entities, including <see cref="Product"/> and <see cref="Category"/>.
        /// </remarks>
        private readonly AppDbContext _context;

        /// <summary>
        /// Provides a repository implementation for managing <see cref="Product"/> entities in the database.
        /// </summary>
        /// <remarks>
        /// The <see cref="ProductRepository"/> is a concrete class implementing the <see cref="IProductRepository"/> interface.
        /// It handles database operations specifically related to <see cref="Product"/> entities, using the <see cref="AppDbContext"/>.
        /// This includes actions such as retrieve, add, update, and delete operations for products.
        /// </remarks>
        private ProductRepository(AppDbContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        //* Methods...
        /// <summary>
        /// Asynchronously retrieves all <see cref="Product"/> entities from the data store.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an enumerable collection of <see cref="Product"/> entities.
        /// </returns>
        public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.ToListAsync();

        /// <summary>
        /// Asynchronously retrieves a <see cref="Product"/> entity by its identifier from the data store.
        /// </summary>
        /// <param name="id">The unique identifier of the <see cref="Product"/> to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation, containing the <see cref="Product"/> entity if found; otherwise, null.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        public async Task<Product?> GetByIdAsync(int id)
        {
            if(id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Invalid product identifier!");

            return await _context.Products.FindAsync(id);
        }

        /// <summary>
        /// Asynchronously retrieves a collection of <see cref="Product"/> entities whose names match the specified value.
        /// </summary>
        /// <param name="name">The name of the product to filter by. This is the value used to search for products in the data store.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of <see cref="Product"/> entities matching the specified name.</returns>
        /// <exception cref="NotImplementedException">Thrown to indicate that the method's implementation is not yet completed.</exception>
        public async Task<IEnumerable<Product>> GetByNameAsync(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid product name!", nameof(name));

            string loweredProductName = name.ToLower();

            return await _context.Products
                .Where((p) => (p.Name != null) && (p.Name.ToLower().Contains(loweredProductName)))
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Product"/> entities where the price matches the specified value.
        /// </summary>
        /// <param name="price">The price value to filter the <see cref="Product"/> entities.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a collection of <see cref="Product"/> entities with the specified price.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        public async Task<IEnumerable<Product>> GetByPriceAsync(decimal price)
        {
            if(price <= 0) throw new ArgumentException("Invalid product price!", nameof(price));

            return await _context.Products
                .Where((p) => p.Price.Equals(price))
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a collection of <see cref="Product"/> entities associated with the specified category identifier.
        /// </summary>
        /// <param name="categoryId">The identifier of the category to filter products by.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains a collection of <see cref="Product"/> entities that belong to the specified category.</returns>
        /// <exception cref="ArgumentException">Thrown when the provided <paramref name="categoryId"/> is invalid (e.g., less than or equal to 0).</exception>
        public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId)
        {
            if(categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId), "Invalid product identifier!");

            return await _context.Products
                .Where((p) => p.CategoryId.Equals(categoryId))
                .ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a collection of <see cref="Product"/> entities filtered by the specified category name.
        /// </summary>
        /// <param name="categoryName">The name of the category to filter products by.</param>
        /// <returns>An asynchronous operation that, when completed, contains an enumerable collection of <see cref="Product"/> entities belonging to the specified category.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        public async Task<IEnumerable<Product>> GetByCategoryNameAsync(string categoryName)
        {
            if(string.IsNullOrWhiteSpace(categoryName)) throw new ArgumentException("Invalid category name!", nameof(categoryName));

            string loweredCategoryName = categoryName.ToLower();

            return await _context.Products
                .Where((p) => (p.Category != null)
                              && (p.Category.Name != null)
                              && (p.Category.Name.ToLower().Contains(loweredCategoryName)))
                .ToListAsync();
        }

        /// <summary>
        /// Asynchronously creates a new <see cref="Product"/> entity and saves it to the database.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> entity to be created and persisted.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the created <see cref="Product"/> entity.</returns>
        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        /// <summary>
        /// Updates the details of an existing <see cref="Product"/> in the database.
        /// </summary>
        /// <param name="product">The <see cref="Product"/> instance containing the updated data.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated <see cref="Product"/> entity.</returns>
        public async Task<Product> UpdateAsync(Product product)
        {
            if(product is null) throw new ArgumentNullException(nameof(product));

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        /// <summary>
        /// Deletes a <see cref="Product"/> entity from the data store based on the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to be deleted.</param>
        /// <returns>The deleted <see cref="Product"/> entity.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the provided identifier is less than or equal to zero.</exception>
        /// <exception cref="ArgumentException">Thrown when no product is found for the provided identifier in the data store.</exception>
        public async Task<Product?> DeleteAsync(int id)
        {
            if(id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Invalid product identifier!");

            Product? product = await GetByIdAsync(id);

            if(product is null) throw new ArgumentException("Product not found!", nameof(id));

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}