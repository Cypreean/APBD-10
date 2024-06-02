using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models;

public class Categories
{
    [Key]
    public int PK_category { get; set; }

    [Required]
    [StringLength(100)]
    public string name { get; set; }

    public ICollection<Products_Categories> ProductsCategories { get; set; }
}