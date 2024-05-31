using BooksWebApi.Entities;
using BooksWebApi.Data;

namespace BooksWebApi.Repositories
{
    public interface IBookService
    {
        public Task<List<BookDetails>> BookListAsync();

        public Task<BookDetails> GetBookDetailByIdAsync(int Id);

        public Task<bool> AddBookAsync(BookDetails BookDetails);

        public Task<bool> UpdateBookAsync(BookDetails BookDetails);

        public Task<bool> DeleteBookAsync(int Id);
        
        public Response convertToResponse(List<BookDetails> bookList, string status, string message);

        public MutationResponse convertToMutationResponse(string status, string message);
    }
}
