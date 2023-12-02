using A3C6TV_HFT_2023241.Models;
using System.Linq;

namespace A3C6TV_HFT_2023241.Repository
{
    public class PoolTableRepository : Repository<PoolTable>, IRepository<PoolTable>
    {
        public PoolTableRepository(TajfunDBContext ctx) : base(ctx)
        { }
        public override PoolTable Read(int id)
        {
            return ctx.PoolTables.FirstOrDefault(t => t.TableId == id);
        }
        public override void Update(PoolTable item)
        {
            var old = Read(item.TableId);
            old.T_kind = item.T_kind;
            ctx.SaveChanges();
        }
    }
}
