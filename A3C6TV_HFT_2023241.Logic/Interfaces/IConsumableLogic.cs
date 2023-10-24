using A3C6TV_HFT_2023241.Models;
using System.Linq;

namespace A3C6TV_HFT_2023241.Logic
{
    public interface IConsumableLogic
    {
        void Create(Consumable item);
        void Delete(int id);
        Consumable Read(int id);
        IQueryable<Consumable> ReadAll();
        void Update(Consumable item);
    }
}