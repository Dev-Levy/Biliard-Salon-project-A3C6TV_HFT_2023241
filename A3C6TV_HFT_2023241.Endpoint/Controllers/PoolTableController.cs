using A3C6TV_HFT_2023241.Logic;
using A3C6TV_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace A3C6TV_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PoolTableController : ControllerBase
    {
        IPoolTableLogic logic;

        public PoolTableController(IPoolTableLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<PoolTable> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public PoolTable Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] PoolTable value)
        {
            logic.Create(value);
        }

        [HttpPut("{id}")]
        public void Update([FromBody] PoolTable value)
        {
            logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
