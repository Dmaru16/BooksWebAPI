using BooksWebApi.Entities;

namespace BooksWebApi.Data
{
    public class Response{
        public List<BookDetails> data {get; set;}
        public int total {get; set;}
        public string status {get; set;}
        public string message {get; set;}
    }

    public class MutationResponse{
        public string status {get; set;}
        public string message {get; set;}
    }
}