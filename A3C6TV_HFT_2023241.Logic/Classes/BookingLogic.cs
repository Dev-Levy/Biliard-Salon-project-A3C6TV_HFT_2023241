using A3C6TV_HFT_2023241.Models;
using A3C6TV_HFT_2023241.Repository;
using System.Linq;

namespace A3C6TV_HFT_2023241.Logic
{
    public class BookingLogic : IBookingLogic
    {
        IRepository<Booking> repo;

        public BookingLogic(IRepository<Booking> inrepo)
        {
            repo = inrepo;
        }

        public void Create(Booking item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Booking Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Booking> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Booking item)
        {
            repo.Update(item);
        }
    }
}
