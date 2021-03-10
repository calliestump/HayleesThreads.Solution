using System.Collections.Generic;

namespace HayleesThreads.Models
{
  public class Category
  {
    public Category()
    {
      this.JoinTables = new HashSet<CategoryProduct>();
    }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }

    public string CategoryDescription { get; set; }
    public virtual ApplicationUser User { get; set; }
    // public List<Product> Products { get; set; }

    public virtual ICollection<CategoryProduct> JoinTables { get; set; }
  }
}