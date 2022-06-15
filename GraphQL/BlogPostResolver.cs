using GraphqlHotChoc.DataAccess.Models;
using HotChocolate;
using HotChocolate.Resolvers;
using System.Linq;

namespace GraphqlHotChoc.GraphQL
{
    public class BlogPostResolver
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostResolver([Service] IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public IEnumerable<BlogPost> GetBlogPosts(Author author, IResolverContext ctx)
        {
            return _blogPostRepository.GetBlogPosts().Where(b => b.AuthorId == author.Id);
        }
        public IEnumerable<BlogPost> GetBlogPostsById(int authorId, IResolverContext ctx)
        {
            return _blogPostRepository.GetBlogPosts().Where(b => b.AuthorId == authorId);
        }
    }
}
