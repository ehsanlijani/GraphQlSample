using Microsoft.EntityFrameworkCore;
using SampleGraphQl.Entities;

namespace SampleGraphQl.Data;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                new User
                {
                    Address = "Test Address",
                    Age = 1,
                    Family = "Family Test",
                    Name = "Name Test",
                    Phone = "0912"
                });
                context.SaveChanges();
            }
            
            if (!context.Articles.Any())
            {
                context.Articles.AddRange(
                new Article
                {
                    Image = "Image1",
                    Description = "description",
                    Like = 50,
                    Title = "title",
                    PublishDate = DateTime.Now,
                    AuthorId = 1,
                },
                new Article
                {
                    Image = "Image2",
                    Description = "description 2",
                    Like = 80,
                    Title = "title 2",
                    PublishDate = DateTime.Now,
                    AuthorId = 1,
                });
                context.SaveChanges();
            }

            if (!context.Tags.Any())
            {
                context.Tags.AddRange(
                new Entities.Tag
                {
                    ArticleId = 1,
                    CreateAt = DateTime.Now,
                    Name = "Tag Test",
                });
                context.SaveChanges();
            }
        }
    }
}
