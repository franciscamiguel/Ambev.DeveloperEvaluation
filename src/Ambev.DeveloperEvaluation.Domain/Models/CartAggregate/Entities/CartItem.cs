using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Entities;

public class CartItem(Guid cartId, Guid productId, int quantity) : BaseEntity
{
    public Guid ProductId { get; private set; } = productId;
    public int Quantity { get; private set; } = quantity;
    public Guid CartId { get; private set; } = cartId;
    public Cart Cart { get; }

    public void UpdateQuantity(int quantity)
    {
        if (quantity <= 0)
            throw new InvalidOperationException("Quantity must be greater than zero.");
        Quantity = quantity;
    }

    public void Update(CartItem itemScreen)
    {
        ProductId = itemScreen.ProductId;
        Quantity = itemScreen.Quantity;
    }
}