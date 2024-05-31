using BooksWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BooksWebApi.Data
{
    public class DbContextClass : DbContext
    {

        public DbContextClass(DbContextOptions<DbContextClass>
options) : base(options)
        {

        }

        public DbSet<BookDetails> Books { get; set; }
    }
}
