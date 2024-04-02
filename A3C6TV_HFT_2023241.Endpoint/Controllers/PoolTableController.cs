using A3C6TV_HFT_2023241.Endpoint.Services;
using A3C6TV_HFT_2023241.Logic;
using A3C6TV_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace A3C6TV_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PoolTableController : ControllerBase
    {
        IPoolTableLogic logic;
        IHubContext<SignalRHub> hub;

        public PoolTableController(IPoolTableLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("PoolTableCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] PoolTable value)
        {
            logic.Update(value);
            hub.Clients.All.SendAsync("PoolTableUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var value = logic.Read(id);
            logic.Delete(id);
            hub.Clients.All.SendAsync("PoolTableDeleted", value);
        }
    }
}
