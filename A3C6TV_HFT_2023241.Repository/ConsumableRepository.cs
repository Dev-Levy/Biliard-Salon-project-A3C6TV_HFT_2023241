using A3C6TV_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3C6TV_HFT_2023241.Repository
{
    public class ConsumableRepository : Repository<Consumable>, IRepository<Consumable>
    {
        public ConsumableRepository(TajfunDBContext ctx) : base(ctx)
        { }
        public override Consumable Read(int id)
        {
            return this.ctx.Consumables.First(t => t.Consumable_ID == id);
        }
        public override void Update(Consumable item)
        {
            var old = Read(item.Consumable_ID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
