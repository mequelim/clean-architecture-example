using CleanArchitectureMvc.Application.DTOs;

namespace CleanArchitectureMvc.Application.Interfaces
{
    /// <summary>
    /// Defines the contract for category-related operations in the application layer.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Asynchronously retrieves all categories.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an enumerable collection of <see cref="CategoryDto"/> objects representing the categories.
        /// </returns>
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();

        /// <summary>
        /// Asynchronously retrieves a category by its unique identifier.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the category to retrieve.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a <see cref="CategoryDto"/> object representing the category with the specified identifier.
        /// </returns>
        Task<CategoryDto> GetCategoryByIdAsync(int id);

        /// <summary>
        /// Asynchronously retrieves categories that match the specified name.
        /// </summary>
        /// <param name="name">
        /// The name or partial name of the categories to retrieve.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an enumerable collection of <see cref="CategoryDto"/> objects representing the matching categories.
        /// </returns>
        Task<CategoryDto> GetCategoriesByNameAsync(string name);

        /// <summary>
        /// Asynchronously creates a new category in the system.
        /// </summary>
        /// <param name="categoryDto">
        /// A <see cref="CategoryDto"/> object containing the details of the category to be created.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task CreateCategoryAsync(CategoryDto categoryDto);

        /// <summary>
        /// Asynchronously updates an existing category in the system.
        /// </summary>
        /// <param name="categoryDto">
        /// A <see cref="CategoryDto"/> object containing the updated details of the category.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task UpdateCategoryAsync(CategoryDto categoryDto);

        /// <summary>
        /// Asynchronously deletes a category from the system by its unique identifier.
        /// </summary>
        /// <param name="id">
        /// The unique identifier of the category to delete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task DeleteCategoryAsync(int id);
    }
}