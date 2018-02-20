using System;
using System.Collections.Generic;
using LMA.Data.Interfaces;
using LMA.Data.Model;
using LMA.Data.Repository;

namespace LMA
{
    public class CustomerRepository : Repository<Customer>,ICustomerRepository
    {
        public CustomerRepository(LMADbContext context) :base(context)
        {

            //constructor
        }



    }
}