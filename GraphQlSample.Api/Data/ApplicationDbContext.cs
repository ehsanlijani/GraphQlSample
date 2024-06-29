using Microsoft.EntityFrameworkCore;
using SampleGraphQl.Entities;
using Tag = SampleGraphQl.Entities.Tag;

namespace SampleGraphQl.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    #region DbSet
    public DbSet<User> Users { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<SampleGraphQl.Entities.Tag> Tags { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Articles)
            .WithOne(u => u.Author!)
            .HasForeignKey(u => u.AuthorId);

        modelBuilder.Entity<Article>()
            .HasOne(a => a.Author)
            .WithMany(a => a.Articles)
            .HasForeignKey(a => a.AuthorId);

        modelBuilder.Entity<Tag>()
            .HasOne(a => a.Article)
            .WithOne(t => t.Tag)
            .HasForeignKey<Tag>(t => t.ArticleId); // Explicitly define the foreign ke

    }
}