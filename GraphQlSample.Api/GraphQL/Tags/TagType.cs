using SampleGraphQl.Data;
using SampleGraphQl.Entities;
using Tag = SampleGraphQl.Entities.Tag;

namespace SampleGraphQl.GraphQL.Tags;

public class TagType(ApplicationDbContext context) : ObjectType<Tag>
{
    private readonly ApplicationDbContext _context = context;

    protected override void Configure(IObjectTypeDescriptor<Tag> descriptor)
    {
        descriptor.Description("این مدل برای تگ ها میباشد.");

        descriptor.Field(a => a.Name).Description("این فیلد نام تگ است.");

        descriptor.Field(a => a.Article)
            .ResolveWith<Resolvers>(a => a.GetTags(default!))
            .UseDbContext<ApplicationDbContext>()
            .Description("تگ این مقاله در این فیلد قرار میکیرد..");

        base.Configure(descriptor);
    }

    public class Resolvers(ApplicationDbContext context)
    {
        public Tag? GetTags(Article article) => context.Tags.FirstOrDefault(u => u.Id == article.TagId);

    }
}
