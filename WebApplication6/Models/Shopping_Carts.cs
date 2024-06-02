using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models;

public class Shopping_Carts
{
    [Key, Column(Order = 0)]
    public int FK_account { get; set; }

    [Key, Column(Order = 1)]
    public int FK_product { get; set; }

    public int amount { get; set; }

    [ForeignKey("FK_account")]
    public Accounts Account { get; set; }

    [ForeignKey("FK_product")]
    public Products Product { get; set; }
}