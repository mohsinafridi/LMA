﻿using LMA.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMA.Data.Interfaces
{
   public  interface IAuthorRepository : IRepository<Author>
    {
        IEnumerable<Author> GetAllWithBooks();

        Author GetWithBooks(int id);
    }
}
