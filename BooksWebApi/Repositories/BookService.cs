using BooksWebApi.Data;
using BooksWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksWebApi.Repositories
{
    public class BookService : IBookService
    {
        private readonly DbContextClass dbContextClass;

        public BookService(DbContextClass dbContextClass)
        {
            this.dbContextClass = dbContextClass;
        }

        public async Task<List<BookDetails>> BookListAsync()
        {
            return await dbContextClass.Books.ToListAsync();
        }

        public async Task<BookDetails> GetBookDetailByIdAsync(int Id)
        {
            return await dbContextClass.Books.Where(ele => ele.BookId == Id).FirstOrDefaultAsync();
        }

        public async Task<bool> AddBookAsync(BookDetails BookDetails)
        {
            await dbContextClass.Books.AddAsync(BookDetails);
            var result = await dbContextClass.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateBookAsync(BookDetails BookDetails)
        {
            var isBook = BookDetailsExists(BookDetails.BookId);
            if (isBook)
            {
                dbContextClass.Books.Update(BookDetails);
                var result = await dbContextClass.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> DeleteBookAsync(int Id)
        {
            var findBookData = dbContextClass.Books.Where(_ => _.BookId == Id).FirstOrDefault();
            if (findBookData != null)
            {
                dbContextClass.Books.Remove(findBookData);
                var result = await dbContextClass.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private bool BookDetailsExists(int Id)
        {
            return dbContextClass.Books.Any(e => e.BookId == Id);
        }

        public Response convertToResponse(List<BookDetails> bookList, string status, string message){
            Response response =  new Response();
            response.data = bookList;
            response.total = bookList.Count;
            response.status = status;
            response.message = message;
            return response;
        }

        public MutationResponse convertToMutationResponse(string status, string message){
            MutationResponse response =  new MutationResponse();
            response.status = status;
            response.message = message;
            return response;
        }
    }
}
