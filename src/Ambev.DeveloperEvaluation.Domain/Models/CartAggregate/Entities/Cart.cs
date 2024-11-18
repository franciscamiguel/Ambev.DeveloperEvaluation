using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Models.CartAggregate.Entities;

public class Cart(Guid userId) : BaseEntity
{
    public Guid UserId { get; private set; } = userId;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }
    
    private readonly List<CartItem> _products = [];
    public IReadOnlyCollection<CartItem> Products => _products;

    public void UpdateItems(CartItem[] products)
    {
        _products.RemoveAll(x => products.All(itemScreen => itemScreen.ProductId != x.ProductId));

        foreach (var itemScreen in products)
        {
            var existingItem = _products.Find(item => item.ProductId == itemScreen.ProductId);

            if (existingItem is not null)
                existingItem.Update(itemScreen);
            else
                _products.Add(itemScreen);
        }
    }

    public void RemoveProduct(Guid productId)
    {
        var product = _products.Find(p => p.ProductId == productId)
                      ?? throw new KeyNotFoundException($"Product with ID {productId} not found in cart.");

        _products.Remove(product);
    }

    public void UpdateDate() => UpdatedAt = DateTime.UtcNow;

    public void AddProduct(Guid productId, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        var existingProduct = _products.FirstOrDefault(p => p.ProductId == productId);
        if (existingProduct is not null)
            existingProduct.UpdateQuantity(quantity);
        else
            _products.Add(new CartItem(Id, productId, quantity));
    }
}