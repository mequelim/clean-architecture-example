using CleanArchitectureMvc.Domain.Entities;

namespace CleanArchitectureMvc.Domain.Interfaces
{
    /// <summary>
    /// Defines the contract for a repository that manages <see cref="Category"/> entities.
    /// </summary>
    /// <remarks>
    /// This interface provides methods for performing CRUD operations on <see cref="Category"/> entities,
    /// such as retrieving all categories, finding a category by its identifier or name, and creating, updating, or deleting categories.
    /// </remarks>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Asynchronously retrieves all <see cref="Category"/> entities from the repository.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an <see cref="IEnumerable{T}"/> of <see cref="Category"/> entities.
        /// </returns>
        /// <remarks>
        /// This method is used to fetch all categories stored in the repository.
        /// It is particularly useful for scenarios where a complete list of categories is required, such as displaying them in a dropdown or a catalog.
        /// </remarks>
        Task<IEnumerable<Category>> GetAllAsync();

        /// <summary>
        /// Asynchronously retrieves a <see cref="Category"/> entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category to retrieve.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the <see cref="Category"/> entity if found; otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// Use this method to fetch a specific category by its identifier.
        /// This is useful in scenarios where detailed information about a single category is required, such as editing or displaying its details.
        /// </remarks>
        Task<Category?> GetByIdAsync(int id);

        /// <summary>
        /// Asynchronously retrieves a <see cref="Category"/> entity by its name.
        /// </summary>
        /// <param name="name">The name of the category to retrieve.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the <see cref="Category"/> entity if found; otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// Use this method to fetch a specific category by its name.
        /// This is useful in scenarios where a category needs to be identified or processed based on its name, such as searching or filtering operations.
        /// </remarks>
        Task<Category?> GetByNameAsync(string name);

        /// <summary>
        /// Asynchronously creates a new <see cref="Category"/> entity in the repository.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> entity to be created.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains the created <see cref="Category"/> entity with its unique identifier populated.
        /// </returns>
        /// <remarks>
        /// Use this method to add a new category to the repository. 
        /// Ensure that the <paramref name="category"/> parameter contains valid data before calling this method.
        /// </remarks>
        Task<Category> CreateAsync(Category category);

        /// <summary>
        /// Asynchronously updates an existing <see cref="Category"/> entity in the repository.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> instance containing the updated data.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated <see cref="Category"/> entity.</returns>
        /// <remarks>
        /// This method is used to modify an existing category within the repository by replacing its data with the provided <see cref="Category"/> instance.
        /// It is typically utilized in scenarios where category details need to be revised.
        /// </remarks>
        Task<Category> UpdateAsync(Category category);

        /// <summary>
        /// Asynchronously deletes a <see cref="Category"/> entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category to delete.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains the deleted <see cref="Category"/> entity if the operation is successful; otherwise, <c>null</c>.
        /// </returns>
        /// <remarks>
        /// Use this method to remove a specific category from the repository.
        /// This is useful in scenarios where a category is no longer needed, such as when it is obsolete or incorrectly added.
        /// </remarks>
        Task<Category?> DeleteAsync(int id);
    }
}