using GraphqlHotChoc.DataAccess;
using GraphqlHotChoc.DataAccess.Models;
using HotChocolate;
using HotChocolate.Subscriptions;
using System.Threading.Tasks;

namespace GraphqlHotChoc.GraphQL
{
    public class Mutation
    {
        public async Task<Author> CreateAuthor(
            [Service] AuthorRepository authorRepository,
            [Service] ITopicEventSender eventSender, 
            int id,
            string firstName,
            string lastName)
        {
            var data = new Author
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName
            };
            var result = await authorRepository.CreateAuthor(data);
            await eventSender.SendAsync("AuthorCreated", result);
            return result;
        }

    }
}
