namespace Ambev.DeveloperEvaluation.Domain.Events;

public class SaleRegisteredEventMessage
{
    public Guid SaleId { get; set; }
    public Guid CustomerId { get; set; }
    public decimal TotalAmount { get; set; }
    public List<SaleProductEventMessage> Products { get; set; }
}