using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;

public class SaleItem : BaseEntity
{
    protected SaleItem()
    {
    }

    public SaleItem(int quantity, decimal unitPrice, Guid productId, Guid saleId)
    {
        ValidateQuantity(quantity);

        Quantity = quantity;
        UnitPrice = unitPrice;
        ProductId = productId;
        SaleId = saleId;
    }

    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Discount { get; private set; }
    public decimal Total { get; private set; }

    public Guid ProductId { get; private set; }
    public Guid SaleId { get; private set; }
    public Sale? Sale { get; }

    private static void ValidateQuantity(int quantity)
    {
        if (quantity > 20)
            throw new InvalidOperationException("Cannot sell more than 20 identical items.");
    }

    public void CalculateDiscount()
    {
        Discount = Quantity switch
        {
            >= 4 and < 10 => 0.1m,
            >= 10 and <= 20 => 0.2m,
            _ => 0m
        };

        Total = Quantity * UnitPrice * (1 - Discount);
    }

    public void Update(SaleItem itemScreen)
    {
        ValidateQuantity(itemScreen.Quantity);

        Quantity = itemScreen.Quantity;
        UnitPrice = itemScreen.UnitPrice;
        ProductId = itemScreen.ProductId;
    }
}