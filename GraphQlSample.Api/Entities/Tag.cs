#nullable disable

namespace SampleGraphQl.Entities;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreateAt { get; set; }

    public long? ArticleId { get; set; }
    public Article Article { get; set; }

}
