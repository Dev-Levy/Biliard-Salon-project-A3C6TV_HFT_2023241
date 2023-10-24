using A3C6TV_HFT_2023241.Models;
using System.Linq;

namespace A3C6TV_HFT_2023241.Logic
{
    public interface ICustomerLogic
    {
        void Create(Customer item);
        void Delete(int id);
        Customer Read(int id);
        IQueryable<Customer> ReadAll();
        void Update(Customer item);
    }
}