using BooksWebApi.Entities;
using BooksWebApi.Repositories;

namespace BooksWebApi.GraphQL.Mutations
{
    public class BookMutations
    {
        public async Task<bool> AddBookAsync([Service] IBookService BookService,
    BookDetails BookDetails)
        {
            return await BookService.AddBookAsync(BookDetails);
        }

        public async Task<bool> UpdateBookAsync([Service] IBookService BookService,
    BookDetails BookDetails)
        {
            return await BookService.UpdateBookAsync(BookDetails);
        }

        public async Task<bool> DeleteBookAsync([Service] IBookService BookService,
   int bookId)
        {
            return await BookService.DeleteBookAsync(bookId);
        }
    }
}
