using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingTaskCS.Models
{
  public class Order
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PurchaseOrderID { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    [ForeignKey("EmployeeID")]
    public virtual Employee Employee { get; set; }
    public int EmployeeID { get; set; }

    public string ShipMethod { get; set; }
    public int Status { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShipDate { get; set; }
    public double SubTotal { get; set; }
    public double Freight { get; set; }
    public double TotalDue { get; set; }
  }

  public class Orders
  {
    public List<Order> Order { get; set; }
  }
}