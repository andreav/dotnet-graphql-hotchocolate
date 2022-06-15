using GraphqlHotChoc.DataAccess;
using GraphqlHotChoc.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Entity
builder.Services.AddDbContextFactory<GraphqlHotChocDbContext>(
    options => options.UseInMemoryDatabase("GraphqlHotChocManagement")
    );

// Repositories
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();

// GraphQL
builder.Services
    .AddGraphQL()
    .AddGraphQLServer()
    .AddType<AuthorType>()
    .AddType<BlogPostType>()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseWebSockets();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.MapGet("/", () => "Hello World!");

app.Run();
