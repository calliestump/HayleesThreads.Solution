using System.Collections.Generic;

namespace HayleesThreads.Models
{
  public class Product
  {
    public Product()
    {
      this.JoinTables = new HashSet<CategoryProduct>();
    }
    public int ProductId { get; set; }
    public string ProductName { get; set; }

    public int ProductPrice { get; set; }

    public string ProductDescription { get; set; }

    public bool Featured { get; set; }

    public bool AllEars { get; set; }
    public int CategoryId { get; set; }
    // public Category Category { get; set;}
    public virtual ApplicationUser User { get; set; }
    
    public virtual ICollection<CategoryProduct> JoinTables { get; set; }
  }
}