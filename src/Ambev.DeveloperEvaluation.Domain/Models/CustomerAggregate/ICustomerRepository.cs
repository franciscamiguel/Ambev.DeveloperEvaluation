using Ambev.DeveloperEvaluation.Domain.Models.CustomerAggregate.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Models.CustomerAggregate;

/// <summary>
///     Repository interface for Customer entity operations
/// </summary>
public interface ICustomerRepository
{
    /// <summary>
    ///     Creates a new customer in the repository
    /// </summary>
    /// <param name="customer">The user to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user</returns>
    Task<Customer> CreateAsync(Customer customer, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a customer by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a customer from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the user was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}