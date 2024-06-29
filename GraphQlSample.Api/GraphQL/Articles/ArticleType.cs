using SampleGraphQl.Data;
using SampleGraphQl.Entities;

namespace SampleGraphQl.GraphQL.Articles;

public class ArticleType : ObjectType<Article>
{
    private readonly ApplicationDbContext _context;
    public ArticleType(ApplicationDbContext context) => _context = context;

    protected override void Configure(IObjectTypeDescriptor<Article> descriptor)
    {
        descriptor.Description("این مدل برای مقاله ها میباشد.");

        descriptor.Field(a => a.Title).Description("این فیلد عنوان مقاله است.");

        //descriptor.Field(a => a.Like).Ignore();

        descriptor.Field(a => a.Author)
            .ResolveWith<Resolvers>(a => a.GetAuthor(default!))
            .UseDbContext<ApplicationDbContext>()
            .Description("نویسنده این مقاله در این فیلد قرار میکیرد..");

        base.Configure(descriptor);
    }

    public class Resolvers
    {
        private readonly ApplicationDbContext _context;
        public Resolvers(ApplicationDbContext context) => _context = context;
        public User? GetAuthor(Article article) => _context.Users.FirstOrDefault(u => u.Id == article.AuthorId);
        
    }

}
