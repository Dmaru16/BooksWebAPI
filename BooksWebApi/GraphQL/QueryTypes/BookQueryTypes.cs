using BooksWebApi.Entities;
using BooksWebApi.Repositories;

namespace BooksWebApi.GraphQL.Types
{
    public class BookQueryTypes
    {
        public async Task<List<BookDetails>> GetBookListAsync([Service] IBookService BookService)
        {
            return await BookService.BookListAsync();
        }

        public async Task<BookDetails> GetBookDetailsByIdAsync([Service] IBookService BookService, int bookId)
        {
            return await BookService.GetBookDetailByIdAsync(bookId);
        }
    }
}
