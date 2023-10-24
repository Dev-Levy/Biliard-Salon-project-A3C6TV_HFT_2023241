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
            if (item.TableId < 1)
            {
                throw new ArgumentException("Invalid ID!\nCannot create it!");
            }
            else if (item.T_kind != TableKind.pool || item.T_kind != TableKind.snooker) //ez már a repository rétegben hibát dobna ha nem lenne jó i guess, meg kell kérdezni!!!!!
            {
                throw new ArgumentException("Invalid TableKind!\nCannot create it!");
            }
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
