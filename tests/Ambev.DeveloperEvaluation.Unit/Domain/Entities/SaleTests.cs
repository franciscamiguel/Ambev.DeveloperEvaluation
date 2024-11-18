using Ambev.DeveloperEvaluation.Domain.Models.SaleAggregate.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Unit tests for the Sale entity.
/// </summary>
public class SaleTests
{
    [Fact(DisplayName = "Given a valid Sale When adding items Then total amount is calculated correctly")]
    public void AddItem_ShouldCalculateTotalAmount()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale(0);
        var item = SaleTestData.GenerateSaleItem(5); // 5 items

        // Act
        sale.AddItem(new SaleItem(item.Quantity, item.UnitPrice, item.ProductId, sale.Id));

        // Assert
        sale.TotalAmount.Should().Be(item.Total);
    }

    [Fact(DisplayName = "Given a Sale When cancelling Then Sale is marked as cancelled")]
    public void Cancel_ShouldMarkSaleAsCancelled()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        sale.Cancel();

        // Assert
        sale.IsCancelled.Should().BeTrue();
    }

    [Fact(DisplayName = "Given a Sale with one item When cancelling the item Then Sale is also cancelled")]
    public void CancelItem_LastItem_ShouldCancelSale()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale(1);
        var itemId = sale.Items.First().Id;

        // Act
        sale.CancelItem(itemId);

        // Assert
        sale.IsCancelled.Should().BeTrue();
    }

    [Fact(DisplayName = "Given a SaleItem When adding more than 20 items Then exception is thrown")]
    public void AddItem_ExceedMaxQuantity_ShouldThrowException()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale(0);

        // Act
        var action = () => sale.AddItem(new SaleItem(21, 50m, Guid.NewGuid(), sale.Id)); // 21 items

        // Assert
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("Cannot sell more than 20 identical items.");
    }

    [Fact(DisplayName = "Given a SaleItem with 3 quantity When calculating discount Then no discount is applied")]
    public void CalculateDiscount_LessThanFourItems_ShouldApplyNoDiscount()
    {
        // Arrange
        var item = SaleTestData.GenerateSaleItem(3); // 3 items

        // Act
        item.CalculateDiscount();

        // Assert
        item.Discount.Should().Be(0);
    }

    [Theory(DisplayName = "Given a SaleItem with valid quantities When calculating discount Then correct discount is applied")]
    [InlineData(4, 0.1)]  // 10% discount for 4 items
    [InlineData(10, 0.2)] // 20% discount for 10 items
    public void CalculateDiscount_ValidQuantities_ShouldApplyCorrectDiscount(int quantity, decimal expectedDiscount)
    {
        // Arrange
        var item = SaleTestData.GenerateSaleItem(quantity);

        // Act
        item.CalculateDiscount();

        // Assert
        item.Discount.Should().Be(expectedDiscount);
    }

    /// <summary>
    /// Tests that validation passes when all sale properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid sale data")]
    public void Given_ValidSaleData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        var result = sale.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }
}
