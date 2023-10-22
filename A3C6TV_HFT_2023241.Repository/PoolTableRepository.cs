using A3C6TV_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3C6TV_HFT_2023241.Repository
{
    public class PoolTableRepository : Repository<PoolTable>, IRepository<PoolTable>
    {
        public PoolTableRepository(TajfunDBContext ctx) : base(ctx)
        { }
        public override PoolTable Read(int id)
        {
            return this.ctx.PoolTables.First(t => t.Table_ID == id);
        }
        public override void Update(PoolTable item)
        {
            var old = Read(item.Table_ID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
