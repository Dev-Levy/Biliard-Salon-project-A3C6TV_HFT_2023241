using A3C6TV_HFT_2023241.Models;
using A3C6TV_HFT_2023241.Repository;
using System.Linq;

namespace A3C6TV_HFT_2023241.Logic
{
    public class ConsumableLogic : IConsumableLogic
    {
        IRepository<Consumable> repo;

        public ConsumableLogic(IRepository<Consumable> inrepo)
        {
            repo = inrepo;
        }

        public void Create(Consumable item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Consumable Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Consumable> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Consumable item)
        {
            repo.Update(item);
        }
    }
}
