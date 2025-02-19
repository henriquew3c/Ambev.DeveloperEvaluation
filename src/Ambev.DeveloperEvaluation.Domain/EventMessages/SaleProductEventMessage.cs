namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleProductEventMessage
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Total { get; set; }
}