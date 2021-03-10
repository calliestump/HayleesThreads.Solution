using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HayleesThreads.Models
{
  public class Product
  {
    public Product()
    {
      this.JoinTables = new HashSet<CategoryProduct>();
      // this.JoinTables2 = new HashSet<ShoppingCartProduct>();
    }

    public int ProductId { get; set; }

    public string ProductName { get; set; }
  
    public decimal ProductPrice { get; set; }

    public string ProductImage { get; set; }
 
    public string ProductDescription { get; set; }

    public bool Featured { get; set; }

    public bool AllEars { get; set; }
    public int CategoryId { get; set; }
    
    // public Cart CurrentCart { get; set; }
    
    public Category Category { get; set;} // Lets hope
    public virtual ApplicationUser User { get; set; }
    
    public virtual ICollection<CategoryProduct> JoinTables { get; set; }
    // public virtual ICollection<ShoppingCartProduct> JoinTables2 { get; set; }
  }
}