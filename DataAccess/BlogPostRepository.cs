using GraphqlHotChoc.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphqlHotChoc.DataAccess
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly IDbContextFactory
            <GraphqlHotChocDbContext> _dbContextFactory;
        public BlogPostRepository(IDbContextFactory<GraphqlHotChocDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using (var applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                applicationDbContext.Database
                .EnsureCreated();
            }
        }
        public List<BlogPost> GetBlogPosts()
        {
            using (var applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                return applicationDbContext
                .BlogPosts.ToList();
            }
        }
        public BlogPost GetBlogPostById(int id)
        {
            using (var applicationDbContext = _dbContextFactory.CreateDbContext())
            {
                return applicationDbContext.BlogPosts.SingleOrDefault(x => x.Id == id);
            }
        }
    }
}
