using System;
using System.ComponentModel.DataAnnotations;

namespace BooksWebApi.Entities
{
    public class BookDetails
    {
        [Key]
        public int BookId { get; set; }
        
        public string Author { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        
        public string Genre { get; set; }
        
        public DateTime PublishedDate { get; set; }

    }

    public class BookList
    {
        public List<BookDetails> books = new List<BookDetails>();

        public void AddBook (int BookId, string Author, string Title, string Genre, DateTime PublishedDate)
        {
            books.Add(new BookDetails { BookId = BookId, Author = Author, Title = Title, Genre = Genre, PublishedDate = PublishedDate });
        }
    }
}
