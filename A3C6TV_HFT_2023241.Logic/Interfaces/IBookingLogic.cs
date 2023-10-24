using A3C6TV_HFT_2023241.Models;
using System.Linq;

namespace A3C6TV_HFT_2023241.Logic
{
    public interface IBookingLogic
    {
        void Create(Booking item);
        void Delete(int id);
        Booking Read(int id);
        IQueryable<Booking> ReadAll();
        void Update(Booking item);
    }
}