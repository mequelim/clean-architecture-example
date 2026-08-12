using AutoMapper;
using CleanArchitectureMvc.Application.DTOs;
using CleanArchitectureMvc.Application.Interfaces;
using CleanArchitectureMvc.Application.Products.Commands;
using CleanArchitectureMvc.Application.Products.Queries;
using CleanArchitectureMvc.Domain.Entities;
using MediatR;

namespace CleanArchitectureMvc.Application.Services
{
    /// <summary>
    /// Provides an implementation of the <see cref="IProductService"/> interface, offering functionality to manage product-related operations within the application.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of <see cref="ProductService"/> using a mapper and a mediator to orchestrate operations and messages.
        /// </summary>
        /// <param name="mapper">An <see cref="IMapper"/> instance used to map objects between different models.</param>
        /// <param name="mediator">An <see cref="IMediator"/> instance used to mediate commands and queries.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="mapper"/> or <paramref name="mediator"/> is null.</exception>
        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Asynchronously retrieves all products.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing a collection of <see cref="ProductDto"/> objects.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the query object is null.</exception>
        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var productsQuery = new GetAllProductsQuery();

            if(productsQuery is null) throw new ArgumentNullException(nameof(productsQuery), "The query object must be provided!");

            IEnumerable<Product> result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        /// <summary>
        /// Retrieves a product by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the product to retrieve.</param>
        /// <returns>A <see cref="ProductDto"/> representing the product with the specified identifier.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="id"/> is less than or equal to zero.</exception>
        /// <exception cref="KeyNotFoundException">Thrown when the product with the specified identifier is not found.</exception>
        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            if(id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Invalid product identifier!");

            var productByIdQuery = new GetProductByIdQuery(id);

            if(productByIdQuery is null) throw new KeyNotFoundException("Product not found!");

            Product productByIdQueryResult = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDto>(productByIdQueryResult);
        }

        /// <summary>
        /// Asynchronously retrieves a collection of products matching the specified name.
        /// </summary>
        /// <param name="name">The name of the product to search for.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="ProductDto"/> representing the products that match the specified name.</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="name"/> is null or consists only of whitespace.</exception>
        /// <exception cref="KeyNotFoundException">Thrown when no products are found for the specified name.</exception>
        public async Task<IEnumerable<ProductDto>> GetProductsByNameAsync(string name)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The product name must be provided!", nameof(name));

            var productByNameQuery = new GetProductsByNameQuery(name);

            if(productByNameQuery is null) throw new KeyNotFoundException("No products found for the specified name!");

            IEnumerable<Product> productsByNameQueryResult = await _mediator.Send(productByNameQuery);

            if((productsByNameQueryResult is null) || (!productsByNameQueryResult.Any())) throw new KeyNotFoundException("No products found for the specified name!");

            return _mapper.Map<IEnumerable<ProductDto>>(productsByNameQueryResult);
        }

        /// <summary>
        /// Retrieves a collection of products filtered by the specified price.
        /// </summary>
        /// <param name="price">The product price used as a filter. Must be greater than zero.</param>
        /// <returns>A task representing the asynchronous operation, containing an enumerable collection of <see cref="ProductDto"/> objects that match the specified price.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="price"/> is less than or equal to zero.</exception>
        /// <exception cref="KeyNotFoundException">Thrown when no products are found for the specified price.</exception>
        public async Task<IEnumerable<ProductDto>> GetProductsByPriceAsync(decimal price)
        {
            if(price <= 0) throw new ArgumentOutOfRangeException(nameof(price), "Invalid product price!");

            var productsByPriceQuery = new GetProductsByPriceQuery(price);

            if(productsByPriceQuery is null) throw new KeyNotFoundException("No products found for the specified price!");

            IEnumerable<Product> productsByPriceNameQueryResult = await _mediator.Send(productsByPriceQuery);

            if((productsByPriceNameQueryResult is null) || (!productsByPriceNameQueryResult.Any())) throw new KeyNotFoundException("No products found for the specified price!");

            return _mapper.Map<IEnumerable<ProductDto>>(productsByPriceNameQueryResult);
        }

        /// <summary>
        /// Retrieves an asynchronous collection of products belonging to a specific category based on the provided category identifier.
        /// </summary>
        /// <param name="categoryId">The unique identifier of the category for which products are to be retrieved.</param>
        /// <returns>A task that represents the asynchronous operation, containing a collection of <see cref="ProductDto"/> corresponding to the specified category.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="categoryId"/> is less than or equal to zero.</exception>
        /// <exception cref="KeyNotFoundException">Thrown when no products are found for the specified category identifier.</exception>
        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryIdAsync(int categoryId)
        {
            if(categoryId <= 0) throw new ArgumentOutOfRangeException(nameof(categoryId), "Invalid category identifier!");

            var productsByCategoryIdQuery = new GetProductsByCategoryIdQuery(categoryId);

            if(productsByCategoryIdQuery is null) throw new KeyNotFoundException("No products found for the specified category ID!");

            IEnumerable<Product> productsByCategoryIdQueryResult = await _mediator.Send(productsByCategoryIdQuery);

            if((productsByCategoryIdQueryResult is null) || (!productsByCategoryIdQueryResult.Any())) throw new KeyNotFoundException("No products found for the specified category ID!");

            return _mapper.Map<IEnumerable<ProductDto>>(productsByCategoryIdQueryResult);
        }

        /// <summary>
        /// Retrieves a collection of products associated with a specific category name.
        /// </summary>
        /// <param name="categoryName">The name of the category for which products are to be retrieved.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains an <see cref="IEnumerable{T}"/> of <see cref="ProductDto"/> objects.</returns>
        /// <exception cref="ArgumentException">Thrown when <paramref name="categoryName"/> is null, empty, or consists only of white-space characters.</exception>
        /// <exception cref="KeyNotFoundException">Thrown when no products are found for the specified category name.</exception>
        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryNameAsync(string categoryName)
        {
            if(string.IsNullOrWhiteSpace(categoryName)) throw new ArgumentException("The category name must be provided!", nameof(categoryName));

            var productsByCategoryNameQuery = new GetProductsByCategoryNameQuery(categoryName);

            if(productsByCategoryNameQuery is null) throw new KeyNotFoundException("No products found for the specified category name!");

            IEnumerable<Product> productsByCategoryNameQueryResult = await _mediator.Send(productsByCategoryNameQuery);

            if((productsByCategoryNameQueryResult is null) || (!productsByCategoryNameQueryResult.Any())) throw new KeyNotFoundException("No products found for the specified category name!");

            return _mapper.Map<IEnumerable<ProductDto>>(productsByCategoryNameQueryResult);
        }

        /// <summary>
        /// Creates a new product asynchronously by mapping the provided DTO to a command and sending it through the mediator.
        /// </summary>
        /// <param name="productDto">The <see cref="ProductDto"/> containing the data of the product to be created.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="productDto"/> is null.</exception>
        public async Task CreateProductAsync(ProductDto productDto)
        {
            if(productDto is null) throw new ArgumentNullException(nameof(productDto), "The product data must be provided!");

            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);

            if(productCreateCommand is null) throw new ArgumentNullException(nameof(productCreateCommand), "The product command must be provided!");

            await _mediator.Send(productCreateCommand);
        }

        /// <summary>
        /// Updates an existing product asynchronously using the provided product data.
        /// </summary>
        /// <param name="productDto">A <see cref="ProductDto"/> object containing the updated product details.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="productDto"/> is null or when the mapped product command is null.</exception>
        public async Task UpdateProductAsync(ProductDto productDto)
        {
            if(productDto is null) throw new ArgumentNullException(nameof(productDto), "The product data must be provided!");

            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);

            if(productUpdateCommand is null) throw new ArgumentNullException(nameof(productUpdateCommand), "The product command must be provided!");

            await _mediator.Send(productUpdateCommand);
        }

        /// <summary>
        /// Removes a product from the system using a specified product identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to be removed.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="id"/> is less than or equal to zero.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the command to remove the product is null.</exception>
        public async Task RemoveProductAsync(int id)
        {
            if(id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Invalid product identifier!");

            var productRemoveCommand = new ProductRemoveCommand(id);

            if(productRemoveCommand is null) throw new ArgumentNullException(nameof(productRemoveCommand), "The product command must be provided!");

            await _mediator.Send(productRemoveCommand);
        }
    }
}