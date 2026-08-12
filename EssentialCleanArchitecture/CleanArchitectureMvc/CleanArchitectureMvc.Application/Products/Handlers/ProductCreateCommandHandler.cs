using CleanArchitectureMvc.Application.Products.Commands;
using CleanArchitectureMvc.Domain.Entities;
using CleanArchitectureMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Handlers;

/// <summary>
/// Handles the logic for processing the creation of a new product in the system.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IRequestHandler{TRequest, TResponse}"/> interface to process commands of type <see cref="ProductCreateCommand"/> and produce a response of type <see cref="Product"/>.
/// It acts as a mediator between the application layer and the domain layer by used the <see cref="IProductRepository"/> to persist the new product entity.
/// </remarks>
/// <exception cref="ArgumentNullException">Thrown when a required dependency, such as <see cref="IProductRepository"/>, or the provided command is null.</exception>
public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Handles the logic for processing the creation of a new product in the system.
    /// </summary>
    /// <remarks>
    /// This class implements the <see cref="IRequestHandler{TRequest, TResponse}"/> interface to process commands of type <see cref="ProductCreateCommand"/> and produce a response of type <see cref="Product"/>.
    /// It utilizes the <see cref="IProductRepository"/> to interact with the data storage layer for persisting the new product.
    /// </remarks>
    /// <exception cref="ArgumentNullException">Thrown when a required dependency, such as <see cref="IProductRepository"/>, or the provided command is null.</exception>
    public ProductCreateCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    //* Method...
    /// <summary>
    /// Handles the creation of a new product based on the provided command.
    /// </summary>
    /// <param name="request">The command containing the product details to be created.</param>
    /// <param name="cancellationToken">A token used to notify the operation should be canceled.</param>
    /// <returns>The created <see cref="Product"/> instance.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the created product instance is null.</exception>
    public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        Product product = new(request.Name, request.Description, request.Price, request.QuantityInStock);

        if(product is null) throw new ArgumentNullException(nameof(product), "The created product instance cannot be null!");

        product.CategoryId = request.CategoryId;

        return await _productRepository.CreateAsync(product);
    }
}