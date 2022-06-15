using GraphqlHotChoc.DataAccess.Models;
using HotChocolate.Types;

namespace GraphqlHotChoc.GraphQL
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(a => a.Id).Type<IdType>();
            descriptor.Field(a => a.FirstName).Type<StringType>();
            descriptor.Field(a => a.LastName).Type<StringType>();
            descriptor.Field<BlogPostResolver>(b => b.GetBlogPostsById(default, default));
            // descriptor.Field("blogsss")
            //           .Argument("authorId", a => a.Type<NonNullType<IntType>>())
            //           .ResolveWith<BlogPostResolver>(b => b.GetBlogPosts(default, default));
        }
    }
}
