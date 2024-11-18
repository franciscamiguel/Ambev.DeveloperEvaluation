using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate;
using Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
///     Implementation of ICartRepository using Entity Framework Core
/// </summary>
public class CartRepository : ICartRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    ///     Initializes a new instance of UserRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public CartRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Creates a new cart in the database
    /// </summary>
    /// <param name="cart">The user to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user</returns>
    public async Task<Cart> CreateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        await _context.Carts.AddAsync(cart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }

    public async Task<Cart> UpdateAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        _context.Carts.Update(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }

    /// <summary>
    ///     Retrieves a cart by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user if found, null otherwise</returns>
    public async Task<Cart?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Carts
            .Include(cart => cart.Products)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<Cart?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _context.Carts
            .Include(cart => cart.Products)
            .FirstOrDefaultAsync(o => o.UserId == userId, cancellationToken);
    }

    public async Task<Cart[]?> GetAsync(CancellationToken cancellationToken = default)
    {
        var carts = await _context.Carts
            .Include(cart => cart.Products)
            .OrderBy(s => s.CreatedAt)
            .ToArrayAsync(cancellationToken);

        return carts;
    }

    /// <summary>
    ///     Deletes a cart from the database
    /// </summary>
    /// <param name="id">The unique identifier of the user to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the user was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cart = await GetByIdAsync(id, cancellationToken);
        if (cart == null)
            return false;

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}