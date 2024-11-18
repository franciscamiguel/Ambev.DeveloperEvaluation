using Ambev.DeveloperEvaluation.Domain.Models.BranchAggregate.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Models.BranchAggregate;

/// <summary>
///     Repository interface for Branch entity operations
/// </summary>
public interface IBranchRepository
{
    /// <summary>
    ///     Creates a new Branch in the repository
    /// </summary>
    /// <param name="branch">The user to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user</returns>
    Task<Branch> CreateAsync(Branch branch, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Retrieves a Branch by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes a branch from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the user was deleted, false if not found</returns>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}