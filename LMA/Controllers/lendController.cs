using LMA.Data.Interfaces;
using LMA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LMA.Controllers
{
    public class LendController:Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICustomerRepository _customerRepository;

        public LendController(IBookRepository bookRepository,ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _customerRepository = customerRepository;
        }
        [Route("Lend")]
        public IActionResult List()
        {
            // load available books
            var availableBooks = _bookRepository.FindWithAuthor(x=>x.BorrowerId==0);
            //check collection
            if (availableBooks.Count() == 0)
            {
                return View("Empty");
                
            }
            else
            {
                return View(availableBooks);

            }
        }

        public IActionResult Lend(int bookId)
        {
            //load current  book an all customers
            var lendVM = new LendViewModel()
            {
                Book = _bookRepository.GetById(bookId),
                Customer = _customerRepository.GetAll()
            };
            // Send data to the Lend View
            return View(lendVM);
        }
        [HttpPost]
        public IActionResult Lend(LendViewModel vm)
        {
            // Update Database
            var book = _bookRepository.GetById(vm.Book.BookId);

            var customer = _customerRepository.GetById(vm.Book.BorrowerId);

            book.Borrower = customer;
            _bookRepository.Update(book);

            return RedirectToAction("List");

        }
    }
}
