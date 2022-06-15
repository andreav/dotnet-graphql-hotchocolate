using GraphqlHotChoc.DataAccess.Models;

public interface IBlogPostRepository
{
    public List<BlogPost> GetBlogPosts();
    public BlogPost GetBlogPostById(int id);
}
