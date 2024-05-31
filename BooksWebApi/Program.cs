using BooksWebApi.Data;
using BooksWebApi.GraphQL.Mutations;
using BooksWebApi.GraphQL.Types;
using BooksWebApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Register Service
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//InMemory Database
builder.Services.AddDbContext<DbContextClass>
(o => o.UseInMemoryDatabase("BooksDB"));

//GraphQL Config
builder.Services.AddGraphQLServer()
    .AddQueryType<BookQueryTypes>()
    .AddMutationType<BookMutations>();

var app = builder.Build();

//GraphQL
app.MapGraphQL();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
