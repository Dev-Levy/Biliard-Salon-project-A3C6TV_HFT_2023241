using A3C6TV_HFT_2023241.Models;
using System.Linq;

namespace A3C6TV_HFT_2023241.Logic
{
    public interface IPoolTableLogic
    {
        void Create(PoolTable item);
        void Delete(int id);
        PoolTable Read(int id);
        IQueryable<PoolTable> ReadAll();
        void Update(PoolTable item);
    }
}