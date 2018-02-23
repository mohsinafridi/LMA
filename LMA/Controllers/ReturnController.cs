using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMA.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMA.Controllers
{
    public class ReturnController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public ReturnController(IBookRepository bookRepository,ICustomerRepository customerRepository)
        {
            this._bookRepository = bookRepository;
            this._customerRepository = customerRepository;
        }
        [Route("Return")]
        public IActionResult List()
        {
            // load all borrowed books
            var borrowedBooks = _bookRepository.FindWithAuthorAndBorrower(x => x.BorrowerId != 0);
            //check the book collections
            if (borrowedBooks == null || borrowedBooks.ToList().Count() == 0)
            {
                return View("Empty");
            }
            return View(borrowedBooks);
        }
        public IActionResult ReturnBook(int bookId)
        {
            //load the book
            var book = _bookRepository.GetById(bookId);
            //remove borrower
            book.Borrower = null;
            book.BorrowerId = 0;

            //update datbase
            _bookRepository.Update(book);
            return RedirectToAction("List");
        }

       
    }
}