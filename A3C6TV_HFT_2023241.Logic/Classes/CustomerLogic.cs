using A3C6TV_HFT_2023241.Models;
using A3C6TV_HFT_2023241.Repository;
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
            repo.Create(item);
        }
        public void Delete(int id)
        {
            repo.Delete(id);
        }
        public Customer Read(int id)
        {
            return repo.Read(id);
        }
        public IQueryable<Customer> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(Customer item)
        {
            repo.Update(item);
        }
    }
}
