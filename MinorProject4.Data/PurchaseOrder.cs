
namespace MinorProject4.Data;

public class PurchaseOrder
{
    public int OrderId { get; set; }
    public int SupplierId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = "";
}
