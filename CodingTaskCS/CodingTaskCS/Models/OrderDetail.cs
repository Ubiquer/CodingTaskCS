using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingTaskCS.Models
{
  public class OrderDetail
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PurchaseOrderDetailID { get; set; }

    [ForeignKey("PurchaseOrderID")]
    public virtual Order Order { get; set; }
    public int? PurchaseOrderID { get; set; }

    [ForeignKey("ProductID")]
    public virtual Product Product { get; set; }
    public int? ProductID { get; set; }

    public int OrderQty { get; set; }
    public double UnitPrice { get; set; }
    public double LineTotal { get; set; }
    public double ReceivedQty { get; set; }
    public double RejectedQty { get; set; }
    public double StockedQty { get; set; }
  }

  public class OrderDetailss
  {
    public List<OrderDetail> OrderDetails { get; set; }
  }
}
