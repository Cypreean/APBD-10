using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models;

public class Roles
{
    [Key]
    public int PK_role { get; set; }

    [Required]
    [StringLength(100)]
    public string name { get; set; }

    public ICollection<Accounts> Accounts { get; set; }
}
