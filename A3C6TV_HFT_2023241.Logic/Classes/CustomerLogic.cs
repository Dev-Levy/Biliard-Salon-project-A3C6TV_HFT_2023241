using A3C6TV_HFT_2023241.Models;
using A3C6TV_HFT_2023241.Repository;
using System;
using System.Linq;

namespace A3C6TV_HFT_2023241.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        IRepository<Customer> repo;

        public CustomerLogic(IRepository<Customer> inrepo)
        {
            repo = inrepo;
        }
        public void Create(Customer item)
        {
            if (!item.Name.Replace(" ", "").Any(ch => char.IsLetter(ch)))
                throw new ArgumentException("Name can't contain anything but letters and space!");

            repo.Create(item);
        }
        public void Delete(int id)
        {
            repo.Delete(id);
        }
        public Customer Read(int id)
        {
            if (repo.Read(id) == null)
                throw new ArgumentException("Customer with this ID doesn't exist!\nCannot read it!");

            return repo.Read(id);
        }
        public IQueryable<Customer> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(Customer item)
        {
            if (repo.Read(item.CustomerId) == null)
            {
                throw new ArgumentException("Customer with this ID doesn't exist!\nCannot update it!");
            }
            repo.Update(item);
        }

    }
}
