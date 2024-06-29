using Microsoft.EntityFrameworkCore;
using SampleGraphQl.Data;
using SampleGraphQl.Entities;
using SampleGraphQl.GraphQL.Articles.Add;
using SampleGraphQl.GraphQL.Articles.Delete;
using SampleGraphQl.GraphQL.Articles.Update;
using SampleGraphQl.GraphQL.Tags.Add;
using SampleGraphQl.GraphQL.Tags.Delete;
using SampleGraphQl.GraphQL.Tags.Update;
using SampleGraphQl.GraphQL.Users.Add;
using SampleGraphQl.GraphQL.Users.Delete;
using SampleGraphQl.GraphQL.Users.Update;
using Tag = SampleGraphQl.Entities.Tag;

namespace SampleGraphQl.GraphQL;

public class Mutation
{
    #region User
    public async Task<AddUserPayload> AddUserAsync(AddUserInput input, [Service] ApplicationDbContext _context)
    {
        var user = new User
        {
            Name = input.Name
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return new AddUserPayload(user);
    }

    public async Task<UpdateUserPayload> UpdateUserAsync(UpdateUserInput input, [Service] ApplicationDbContext _context)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == input.Id);
        if (user is null)
            return null;

        user.Name = input.Name;
        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return new UpdateUserPayload(user);
    }



    public async Task<DeleteUserPayload> DeleteUserAsync(DeleteUserInput input, [Service] ApplicationDbContext _context)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == input.Id);
        if (user is null)
            return new DeleteUserPayload("Not Deleted!!");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return new DeleteUserPayload("Deleted!!");
    }
    #endregion

    #region Article

    public async Task<AddArticlePayload> AddArticleAsync(AddArticleInput input, [Service] ApplicationDbContext _context)
    {
        var aricle = new Article
        {
            Title = input.Title,
            Description = input.Description,
            AuthorId = input.AuthorId
        };


        await _context.Articles.AddAsync(aricle);
        await _context.SaveChangesAsync();

        return new AddArticlePayload(aricle);
    }

    public async Task<UpdateArticlePayload> UpdateArticleAsync(UpdateArticleInput input, [Service] ApplicationDbContext _context)
    {
        var article = await _context.Articles.FirstOrDefaultAsync(x => x.Id == input.ArticleId);

        if (article is null)
            return null;

        article.Title = input.Title;
        article.Description = input.Description;

        _context.Articles.Update(article);
        await _context.SaveChangesAsync();

        return new UpdateArticlePayload(article);
    }

    public async Task<DeleteArticlePayload> DeleteArticleAsync(DeleteArticleInput input, [Service] ApplicationDbContext _context)
    {
        var article = await _context.Articles.FirstOrDefaultAsync(x => x.Id == input.ArticleId);

        if (article is null)
            return new DeleteArticlePayload("Not Deleted!!");

        _context.Articles.Remove(article);
        await _context.SaveChangesAsync();

        return new DeleteArticlePayload("Deleted!!");
    }

    #endregion

    #region Tag
    public async Task<AddTagPayload> AddTagAsync(AddTagInput input, [Service] ApplicationDbContext _context)
    {
        var tag = new Tag
        {
          Name = input.Name
        };

        await _context.Tags.AddAsync(tag);
        await _context.SaveChangesAsync();

        return new AddTagPayload(tag);
    }

    public async Task<UpdateTagPayload> UpdateTagAsync(UpdateTagInput input, [Service] ApplicationDbContext _context)
    {
        var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == input.TagId);

        if (tag is null)
            return null;

        tag.Name = input.Name;

        _context.Tags.Update(tag);
        await _context.SaveChangesAsync();

        return new UpdateTagPayload(tag);
    }
    public async Task<DeleteTagPayload> DeleteTagAsync(DeleteTagInput input, [Service] ApplicationDbContext _context)
    {
        var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == input.TagId);

        if (tag is null)
            return new DeleteTagPayload("Not Deleted!!");

        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync();

        return new DeleteTagPayload("Deleted!!");
    }

    #endregion

}
