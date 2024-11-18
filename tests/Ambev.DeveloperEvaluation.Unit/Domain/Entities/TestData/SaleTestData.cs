using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data for the Sale entity.
/// </summary>
public static class SaleTestData
{
    private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
        .CustomInstantiator(_ => new Sale())
        .RuleFor(s => s.SaleNumber, f => f.Commerce.Ean13())
        .RuleFor(s => s.CustomerId, _ => Guid.NewGuid())
        .RuleFor(s => s.BranchId, _ => Guid.NewGuid())
        .RuleFor(s => s.TotalAmount, _ => 0m) // Calculated dynamically
        .RuleFor(s => s.IsCancelled, _ => false);

    private static readonly Faker<SaleItem> SaleItemFaker = new Faker<SaleItem>()
        .CustomInstantiator(f => new SaleItem(
            quantity: f.Random.Int(1, 20),
            unitPrice: f.Finance.Amount(10, 100),
            productId: Guid.NewGuid(),
            saleId: Guid.NewGuid()
        ));

    /// <summary>
    /// Generates a valid Sale with a random number of items.
    /// </summary>
    /// <param name="itemCount">Number of items to generate.</param>
    /// <returns>A valid Sale entity with items.</returns>
    public static Sale GenerateValidSale(int itemCount = 3)
    {
        var sale = SaleFaker.Generate();
        sale.Id = Guid.NewGuid();

        var items = SaleItemFaker.Generate(itemCount);

        foreach (var itemToAdd in items.Select(item =>
                     new SaleItem(item.Quantity, item.UnitPrice, item.ProductId, sale.Id)
                     {
                         Id = Guid.NewGuid()
                     }))
        {
            sale.AddItem(itemToAdd);
        }

        sale.Calculate();

        return sale;
    }

    /// <summary>
    /// Generates a SaleItem with a specific quantity.
    /// </summary>
    /// <param name="quantity">The quantity of the SaleItem.</param>
    /// <returns>A SaleItem entity.</returns>
    public static SaleItem GenerateSaleItem(int quantity)
    {
        return SaleItemFaker.Clone()
            .RuleFor(i => i.Quantity, quantity)
            .Generate();
    }
}