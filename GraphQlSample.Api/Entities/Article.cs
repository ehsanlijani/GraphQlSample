using System.ComponentModel.DataAnnotations;

namespace SampleGraphQl.Entities;

public class Article
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string Title { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public int? Like { get; set; }
    public DateTime? PublishDate { get; set; }

    public int TagId { get; set; }
    public Tag? Tag { get; set; }
    public long? AuthorId { get; set; }
    public User? Author { get; set; }

}
