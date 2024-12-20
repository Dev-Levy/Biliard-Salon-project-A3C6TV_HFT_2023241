﻿using A3C6TV_HFT_2023241.Models;
using System.Linq;

namespace A3C6TV_HFT_2023241.Repository
{
    public class CustomerRepository : Repository<Customer>, IRepository<Customer>
    {
        public CustomerRepository(TajfunDBContext ctx) : base(ctx)
        { }
        public override Customer Read(int id)
        {
            return ctx.Customers.FirstOrDefault(t => t.CustomerId == id);
        }
        public override void Update(Customer item)
        {
            var old = Read(item.CustomerId);
            old.Name = item.Name;
            old.Phone = item.Phone;
            old.Email = item.Email;
            ctx.SaveChanges();
        }
    }
}
