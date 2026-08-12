using CleanArchitectureMvc.Domain.Entities;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Queries;

/// <summary>
/// Represents a query for retrieving a product by its unique identifier.
/// </summary>
/// <remarks>
/// This query is designed to fetch a single instance of <see cref="Product"/> from the data source based on the provided product ID.
/// It is handled by a corresponding MediatR handler.
/// </remarks>
public class GetProductByIdQuery : IRequest<Product>
{
    /// <summary>
    /// Gets or sets the unique identifier of the product.
    /// </summary>
    /// <remarks>
    /// This property is used to specify the ID of a product to identify and retrieving it, particularly in queries such as <see cref="GetProductByIdQuery"/>.
    /// </remarks>
    public int Id { get; set; }

    /// <summary>
    /// Represents a query to retrieve a specific product by its unique identifier.
    /// </summary>
    /// <remarks>
    /// This query is part of the application's product querying feature and is intended to be used with MediatR.
    /// It retrieves a <see cref="Product"/> object corresponding to the specified ID.
    /// </remarks>
    public GetProductByIdQuery(int id) => Id = id;
}