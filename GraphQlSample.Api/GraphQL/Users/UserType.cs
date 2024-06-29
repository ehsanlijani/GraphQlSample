using SampleGraphQl.Data;
using SampleGraphQl.Entities;

namespace SampleGraphQl.GraphQL.Users;

public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.Description("در این مدل کاربران وجود دارند هر کاربر میتواند یک نویسنده هم باشد.");

        descriptor.Field(u => u.Name).Description("نام کاربر در این فیلد قرار دارد.");

    }

    private class Resolvers
    {
        private readonly ApplicationDbContext _context;
        public Resolvers(ApplicationDbContext context)
            => _context = context;

        public IQueryable<Article> GetArticles(User user)
        {
            return _context.Articles.Where(a => a.AuthorId == user.Id);
        }
    }

}
