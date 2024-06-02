using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models;

public class Products
{
    [Key]
    public int PK_product { get; set; }

    [Required]
    [StringLength(100)]
    public string name { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal weight { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal width { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal height { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal depth { get; set; }

    public ICollection<Products_Categories> ProductsCategories { get; set; }
    public ICollection<Shopping_Carts> ShoppingCarts { get; set; }
}