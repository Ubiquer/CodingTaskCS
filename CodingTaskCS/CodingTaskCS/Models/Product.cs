using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingTaskCS.Models
{
  public class Product
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductID { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    public string Name { get; set; }
    public string ProductModel { get; set; }
    public string Description { get; set; }
  }

  public class Products
  {
    public List<Product> Product { get; set; }
  }
}