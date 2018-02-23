using LMA.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMA.ViewModels
{
    public class BookEditViewModel
    {
        public Book Book{ get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}
