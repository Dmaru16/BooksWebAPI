using BooksWebApi.Repositories;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BooksWebApi.Entities;

namespace  BooksWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        
        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get([Service] IBookService BookService)
        {
            
            var bookList = await BookService.BookListAsync();
            return new JsonResult(BookService.convertToResponse(bookList, "200", "list fetched successfully."));

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get([Service] IBookService BookService, int id)
        {
            var book = await BookService.GetBookDetailByIdAsync(id);
            BookList bookList = new BookList();
            string message = "object fetched successfully";
            string status = "200";
            if (book != null){
                bookList.AddBook(book.BookId, book.Author, book.Title, book.Genre, book.PublishedDate);
                return new JsonResult(BookService.convertToResponse(bookList.books, status, message));
           
            } else {
                message = "object not found";
                status = "404";
                JsonResult res = new JsonResult(BookService.convertToResponse(bookList.books, status, message));
                res.StatusCode = 404;
                return res;
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([Service] IBookService BookService, [FromBody] BookDetails bookDetails)
        {
            var isAdded = await BookService.AddBookAsync(bookDetails);
            string status = null;
            string message = null;
            if (isAdded){
                status = "200";
                message = "Added successfully";
            } else {
                status = "422";
                message = "object not added. unprocessable entity";
                JsonResult res = new JsonResult(BookService.convertToMutationResponse( status, message));
                res.StatusCode = 422;
                return res;
            }
            return new JsonResult(BookService.convertToMutationResponse( status, message));

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([Service] IBookService BookService, int id, [FromBody] BookDetails bookDetails)
        {
            string status = null;
            string message = null;
            if(bookDetails.BookId != id){
                status = "400";
                message = "Bad Request! request body has different BookId than in api path";

                JsonResult res = new JsonResult(BookService.convertToMutationResponse( status, message));
                res.StatusCode = 400;
                return res;
            }

             
            
            var isUpdated = await BookService.UpdateBookAsync(bookDetails);
            if (isUpdated){
                status = "200";
                message = "Updated successfully";
            } else {
                status = "404";
                message = "object not found";
                JsonResult res = new JsonResult(BookService.convertToMutationResponse( status, message));
                res.StatusCode = 404;
                return res;
            }
            return new JsonResult(BookService.convertToMutationResponse( status, message));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([Service] IBookService BookService, int id)
        {
            string status = null;
            string message = null;
            var isDeleted = await BookService.DeleteBookAsync(id);
            if (isDeleted){
                status = "200";
                message = "Deleted successfully";
            } else {
                status = "404";
                message = "object not found";
                JsonResult res = new JsonResult(BookService.convertToMutationResponse( status, message));
                res.StatusCode = 404;
                return res;
            }
            return new JsonResult(BookService.convertToMutationResponse( status, message));
        }

    }

}