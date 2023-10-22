using A3C6TV_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3C6TV_HFT_2023241.Repository
{
    public class BookingRepository : Repository<Booking>, IRepository<Booking>
    {
        public BookingRepository(TajfunDBContext ctx) : base(ctx)
        { }
        public override Booking Read(int id)
        {
            return this.ctx.Bookings.First(t => t.Booking_ID == id);
        }
        public override void Update(Booking item)
        {
            var old = Read(item.Booking_ID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
