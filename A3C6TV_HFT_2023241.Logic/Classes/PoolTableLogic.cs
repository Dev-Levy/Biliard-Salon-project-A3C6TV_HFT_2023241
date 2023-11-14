using A3C6TV_HFT_2023241.Models;
using A3C6TV_HFT_2023241.Repository;
using System;
using System.Linq;

namespace A3C6TV_HFT_2023241.Logic
{
    public class PoolTableLogic : IPoolTableLogic
    {
        IRepository<PoolTable> repo;

        public PoolTableLogic(IRepository<PoolTable> inrepo)
        {
            repo = inrepo;
        }
        public void Create(PoolTable item)
        {
            if (item.T_kind != "pool" && item.T_kind != "snooker")
                throw new ArgumentException("Table type is not okay, it has to be 'pool' or 'snooker'!");

            repo.Create(item);
        }
        public void Delete(int id)
        {
            if (repo.Read(id) == null)
            {
                throw new ArgumentException("Table with this ID doesn't exist!\nCannot delete it!");
            }
            repo.Delete(id);
        }
        public PoolTable Read(int id)
        {
            if (repo.Read(id) == null)
            {
                throw new ArgumentException("Table with this ID doesn't exist!\nCannot read it!");
            }
            return repo.Read(id);
        }
        public IQueryable<PoolTable> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(PoolTable item)
        {
            if (repo.Read(item.TableId) == null)
            {
                throw new ArgumentException("Table with this ID doesn't exist!\nCannot update!");
            }
            repo.Update(item);
        }
    }
}
