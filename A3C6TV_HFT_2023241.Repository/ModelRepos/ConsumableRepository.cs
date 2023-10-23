using A3C6TV_HFT_2023241.Models;
using System.Linq;

namespace A3C6TV_HFT_2023241.Repository
{
    public class ConsumableRepository : Repository<Consumable>, IRepository<Consumable>
    {
        public ConsumableRepository(TajfunDBContext ctx) : base(ctx)
        { }
        public override Consumable Read(int id)
        {
            return ctx.Consumables.FirstOrDefault(t => t.ConsumableId == id);
        }
        public override void Update(Consumable item)
        {
            var old = Read(item.ConsumableId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
