using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Models.CartAggregate;

/// <summary>
///     Repository interface for Cart entity operations
/// </summary>
public interface ICartRepository
{
    /// <summary>
    ///     Creates a new cart in the repository
    /// </summary>
    /// <param name="cart">The user to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user</returns>
    Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default);

    Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a cart by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Cart?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task<Cart[]?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a cart from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the user was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}