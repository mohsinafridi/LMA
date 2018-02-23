using LMA.Data.Model;
using System.Collections.Generic;

namespace LMA.ViewModels
{
    public class LendViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Customer> Customer { get; set; }
    }
}
