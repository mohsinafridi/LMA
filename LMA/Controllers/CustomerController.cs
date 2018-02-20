using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMA.Data.Interfaces;
using LMA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LMA.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBookRepository _bookRepository;

        public CustomerController(ICustomerRepository customRepository,IBookRepository bookRepository)
        {
            _customerRepository = customRepository;
            _bookRepository = bookRepository;
        }
        [Route("Customer")]
        public IActionResult List()
        {
            var customerVM = new List<CustomerViewModel>();
            var customers = _customerRepository.GetAll();
            if (customers.Count() == 0)
            {
                return View("Empty");
            }
            foreach (var cust in customers)
            {
                customerVM.Add(new CustomerViewModel
                {
                    Customer = cust,
                    BookCount = _bookRepository.Count(x => x.BorrowerId == cust.CustomerId)
                });
            }
            return View(customerVM);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}