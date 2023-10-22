using A3C6TV_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3C6TV_HFT_2023241.Repository
{
    public class CustomerRepository : Repository<Customer>, IRepository<Customer>
    {
        public CustomerRepository(TajfunDBContext ctx) : base(ctx)
        { }
        public override Customer Read(int id)
        {
            return this.ctx.Customers.First(t => t.Customer_ID == id);
        }
        public override void Update(Customer item)
        {
            var old = Read(item.Customer_ID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
