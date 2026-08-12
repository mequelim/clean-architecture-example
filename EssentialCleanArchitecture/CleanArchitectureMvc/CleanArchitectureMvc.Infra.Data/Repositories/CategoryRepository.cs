using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;
using CleanArchitectureMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureMvc.Infra.Data.Repositories
{
    /// <summary>
    /// Repository implementation for managing <see cref="Category"/> entities.
    /// </summary>
    /// <remarks>
    /// This class provides the concrete implementation of the <see cref="ICategoryRepository"/> interface, and it interacts with the database using the <see cref="AppDbContext"/>.
    /// It is responsible for performing CRUD operations and querying category data.
    /// </remarks>
    public class CategoryRepository : ICategoryRepository
    {
        /// <summary>
        /// Represents the application's database context utilized for performing operations on the database entities related to <see cref="Category"/> and other domain models.
        /// </summary>
        /// <remarks>
        /// This field is an instance of the <see cref="AppDbContext"/> class and is responsible for providing access to the underlying database to perform CRUD operations and queries.
        /// The context is used extensively in the repository layer to interact with the database through Entity Framework Core.
        /// </remarks>
        private readonly AppDbContext _context;

        /// <summary>
        /// Implements the category repository for handling data access logic related to <see cref="Category"/> entities.
        /// </summary>
        /// <remarks>
        /// This repository is a concrete implementation of the <see cref="ICategoryRepository"/> interface, utilizing <see cref="AppDbContext"/> for interacting with the database.
        /// It encapsulates methods for CRUD operations and additional querying capabilities specific to categories.
        /// </remarks>
        private CategoryRepository(AppDbContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        //* Methods...
        /// <summary>
        /// Asynchronously retrieves all <see cref="Category"/> entities from the data source.
        /// </summary>
        /// <remarks>
        /// This method queries the database context to fetch all categories and returns them as an enumerable collection.
        /// </remarks>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing all <see cref="Category"/> entities.
        /// </returns>
        public async Task<IEnumerable<Category>> GetAllAsync() => await _context.Categories.ToListAsync();

        /// <summary>
        /// Retrieves a <see cref="Category"/> entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category to retrieve. Must be greater than zero.</param>
        /// <returns>Returns the <see cref="Category"/> entity if found; otherwise, returns null.</returns>
        /// <exception cref="ArgumentException">Thrown when the provided category identifier is invalid (less than or equal to zero).</exception>
        public async Task<Category?> GetByIdAsync(int id)
        {
            if(id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Invalid product identifier!");

            return await _context.Categories.FindAsync(id);
        }

        /// <summary>
        /// Asynchronously retrieves a <see cref="Category"/> entity based on its name.
        /// </summary>
        /// <param name="name">The name of the category to search for. Must be a non-empty, non-whitespace string.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the <see cref="Category"/> matching the specified name, or null if no match is found.</returns>
        /// <exception cref="ArgumentException">Thrown when the provided <paramref name="name"/> is null, empty, or consists only of white spaces.</exception>
        public async Task<Category?> GetByNameAsync(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid category name!", nameof(name));

            return await _context.Categories.FirstOrDefaultAsync((c) => c.Name == name);
        }

        /// <summary>
        /// Asynchronously creates a new <see cref="Category"/> entity in the database.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> entity to be created and added to the database.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="Category"/> entity.</returns>
        public async Task<Category> CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        /// <summary>
        /// Updates an existing <see cref="Category"/> entity in the database.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> entity to be updated. It must not be null.</param>
        /// <returns>Returns the updated <see cref="Category"/> entity after saving changes to the database.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="category"/> argument is null.</exception>
        public async Task<Category> UpdateAsync(Category category)
        {
            if(category is null) throw new ArgumentNullException(nameof(category));

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }

        /// <summary>
        /// Deletes a <see cref="Category"/> entity based on the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the <see cref="Category"/> to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deleted <see cref="Category"/> entity if the operation is successful, or <c>null</c> if no matching entity is found.</returns>
        /// <exception cref="NotImplementedException">Thrown if the method is not implemented.</exception>
        public async Task<Category?> DeleteAsync(int id)
        {
            if(id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Invalid product identifier!");

            Category category = await GetByIdAsync(id) ?? throw new ArgumentException("Category not found!", nameof(id));

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}