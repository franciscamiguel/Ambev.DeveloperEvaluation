using Ambev.DeveloperEvaluation.Domain.Models.ProductAggregate.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Models.ProductAggregate;

/// <summary>
///     Repository interface for Product entity operations
/// </summary>
public interface IProductRepository
{
    /// <summary>
    ///     Creates a new Product in the repository
    /// </summary>
    /// <param name="product">The user to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user</returns>
    Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a Product by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a Product from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the user was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}