#nullable disable

using System.ComponentModel.DataAnnotations;

namespace SampleGraphQl.Entities;

public class User
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string Name { get; set; }
    public string Family { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public int? Age { get; set; }

    public ICollection<Article> Articles { get; set; }
}
