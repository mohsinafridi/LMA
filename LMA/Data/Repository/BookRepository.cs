using LMA.Data.Interfaces;
using LMA.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMA.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(LMADbContext context) :base(context)
        {

        }

        public IEnumerable<Book> FindByAuthor(Func<Task, bool> predicate)
        {
            return _context.Books
                .Include(x => x.Author)
                .Where(predicate);
        }

        public IEnumerable<Book> FindByAuthorAndBorrower(Func<Task, bool> predicate)
        {
            return _context.Books
                .Include(a => a.Author)
                .Include(a => a.Borrower)
                .Where(predicate);
        }

        public IEnumerable<Book> GetAllWithAuthor()
        {
            return _context.Books.Include(a => a.Author);
        }
    }
}
