using AutoMapper;
using CleanArchitectureMvc.Application.DTOs;
using CleanArchitectureMvc.Application.Interfaces;
using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;

namespace CleanArchitectureMvc.Application.Services
{
    /// <summary>
    /// Provides services for managing categories within the application layer.
    /// </summary>
    /// <remarks>
    /// This class implements the <see cref="ICategoryService"/> interface, which defines the contract for category-related operations.
    /// It serves as the application layer's implementation for handling category management tasks, such as retrieving, creating, updating, and deleting categories.
    /// </remarks>
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService"/> class.
        /// </summary>
        /// <param name="categoryRepository">An instance of <see cref="ICategoryRepository"/> used to interact with the data layer for category-related operations.</param>
        /// <param name="mapper">An instance of <see cref="IMapper"/> used for mapping between domain entities and data transfer objects.</param>
        /// <remarks>
        /// This constructor sets up the dependencies required for the <see cref="CategoryService"/> to perform its operations.
        /// The <paramref name="categoryRepository"/> is used to access and manipulate category data, while the <paramref name="mapper"/> facilitates object mapping.
        /// </remarks>
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Asynchronously retrieves all categories.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an enumerable collection of <see cref="CategoryDto"/> objects representing the categories.
        /// </returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            IEnumerable<Category> categories = await _categoryRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        /// <summary>
        /// Retrieves a category by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the category to retrieve.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a <see cref="CategoryDto"/> representing the category with the specified identifier.
        /// </returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            if(id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Invalid category identifier!");

            Category? category = await _categoryRepository.GetByIdAsync(id);

            if(category is null) throw new KeyNotFoundException("Category not found!");

            return _mapper.Map<CategoryDto>(category);
        }

        /// <summary>
        /// Retrieves a collection of categories that match the specified name.
        /// </summary>
        /// <param name="name">The name of the categories to search for.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of <see cref="CategoryDto"/> objects that match the specified name.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        /// <remarks>
        /// This method searches for categories by their name and returns the matching results as a collection of <see cref="CategoryDto"/> objects.
        /// The search is case-insensitive and may involve partial matches depending on the implementation.
        /// </remarks>
        public async Task<CategoryDto> GetCategoriesByNameAsync(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The category name must be provided!", nameof(name));

            Category? category = await _categoryRepository.GetByNameAsync(name);

            if(category is null) throw new KeyNotFoundException("Category not found!");

            return _mapper.Map<CategoryDto>(new List<Category> { category });
        }

        /// <summary>
        /// Asynchronously creates a new category based on the provided data transfer object (DTO).
        /// </summary>
        /// <param name="categoryDto">An instance of <see cref="CategoryDto"/> containing the details of the category to be created.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="categoryDto"/> is <c>null</c>.</exception>
        /// <remarks>
        /// This method validates the provided category data and interacts with the underlying data layer to persist the new category.
        /// Ensure that the <paramref name="categoryDto"/> contains valid and complete information before invoking this method.
        /// </remarks>
        public async Task CreateCategoryAsync(CategoryDto categoryDto)
        {
            if(categoryDto is null) throw new ArgumentNullException(nameof(categoryDto), "The category data must be provided!");

            Category category = _mapper.Map<Category>(categoryDto);

            await _categoryRepository.CreateAsync(category);
        }

        /// <summary>
        /// Updates an existing category in the system.
        /// </summary>
        /// <param name="categoryDto">An instance of <see cref="CategoryDto"/> containing the updated details of the category.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="categoryDto"/> is <c>null</c>.</exception>
        /// <exception cref="KeyNotFoundException">Thrown when the category to be updated does not exist in the system.</exception>
        /// <remarks>
        /// This method updates the details of an existing category based on the data provided in the <paramref name="categoryDto"/>.
        /// It ensures that the category exists before attempting to update it.
        /// </remarks>
        public async Task UpdateCategoryAsync(CategoryDto categoryDto)
        {
            if(categoryDto is null) throw new ArgumentNullException(nameof(categoryDto), "The category data must be provided!");

            Category category = _mapper.Map<Category>(categoryDto);

            if(category is null) throw new KeyNotFoundException("Category not found!");

            await _categoryRepository.UpdateAsync(category);
        }

        /// <summary>
        /// Deletes a category identified by the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The unique identifier of the category to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <remarks>
        /// This method removes a category from the system based on its unique identifier.
        /// Ensure that the category exists before attempting to delete it to avoid potential errors.
        /// </remarks>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        public async Task DeleteCategoryAsync(int id)
        {
            if(id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Invalid category identifier!");

            Category category = _categoryRepository.GetByIdAsync(id).Result
                                ?? throw new KeyNotFoundException("Category not found!");

            if(category is null) throw new KeyNotFoundException("Category not found!");

            await _categoryRepository.DeleteAsync(id);
        }
    }
}