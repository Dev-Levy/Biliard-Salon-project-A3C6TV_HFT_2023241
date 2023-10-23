using A3C6TV_HFT_2023241.Models;
using System.Linq;

namespace A3C6TV_HFT_2023241.Repository
{
    public class BookingRepository : Repository<Booking>, IRepository<Booking>
    {
        public BookingRepository(TajfunDBContext ctx) : base(ctx)
        { }
        public override Booking Read(int id)
        {
            return ctx.Bookings.FirstOrDefault(t => t.BookingId == id);
        }
        public override void Update(Booking item)
        {
            var old = Read(item.BookingId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
