using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate;

/// <summary>
///     Repository interface for Sale entity operations
/// </summary>
public interface ISaleRepository
{
    /// <summary>
    ///     Creates a new sale in the repository
    /// </summary>
    /// <param name="sale">The user to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user</returns>
    Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Update a sale
    /// </summary>
    /// <param name="sale"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Sale> UpdateAsync(Sale sale, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a sale by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    Task<Sale?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<Sale[]?> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a sale from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the user was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}