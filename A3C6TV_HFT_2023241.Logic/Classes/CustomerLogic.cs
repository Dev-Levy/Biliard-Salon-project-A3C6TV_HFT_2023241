using A3C6TV_HFT_2023241.Models;
using A3C6TV_HFT_2023241.Repository;
using System;
using System.Linq;

namespace A3C6TV_HFT_2023241.Logic
{
    public class CustomerLogic
    {

        IRepository<Customer> repo;

        public CustomerLogic(IRepository<Customer> inrepo)
        {
            this.repo = inrepo;
        }

        public void Create(Customer item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Customer Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Customer> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
