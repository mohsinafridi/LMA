using LMA.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMA.Data.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetAllWithAuthor();

        IEnumerable<Book> FindByAuthor(Func<Task, bool> predicate);

        IEnumerable<Book> FindByAuthorAndBorrower(Func<Task, bool> predicate);
    }
}
