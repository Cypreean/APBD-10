using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models;

public class Accounts
{
    [Key]
    public int PK_account { get; set; }

    [Required]
    public int FK_role { get; set; }

    [Required]
    [StringLength(50)]
    public string first_name { get; set; }

    [Required]
    [StringLength(50)]
    public string last_name { get; set; }

    [Required]
    [StringLength(80)]
    public string email { get; set; }

    [StringLength(9)]
    public string phone { get; set; }

    [ForeignKey("FK_role")]
    public Roles Role { get; set; }

    public ICollection<Shopping_Carts> ShoppingCarts { get; set; }
}