using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models;

public class Products_Categories
{
    [Key, Column(Order = 0)]
    public int FK_product { get; set; }

    [Key, Column(Order = 1)]
    public int FK_category { get; set; }

    [ForeignKey("FK_product")]
    public Products Product { get; set; }

    [ForeignKey("FK_category")]
    public Categories Category { get; set; }
}