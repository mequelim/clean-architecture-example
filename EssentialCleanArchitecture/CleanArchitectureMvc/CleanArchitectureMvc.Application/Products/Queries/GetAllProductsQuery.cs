using CleanArchitectureMvc.Domain.Entities;
using MediatR;

namespace CleanArchitectureMvc.Application.Products.Queries;

/// <summary>
/// Represents a query to retrieve all products in the system.
/// </summary>
/// <remarks>
/// This query is part of the application layer and retrieves a collection of <see cref="Product"/> entities.
/// It implements the <see cref="IRequest{T}"/> interface with a result type of <c>IEnumerable&lt;Product&gt;</c>, integrating with MediatR for handling CQRS patterns.
/// </remarks>
public class GetAllProductsQuery : IRequest<IEnumerable<Product>> { }