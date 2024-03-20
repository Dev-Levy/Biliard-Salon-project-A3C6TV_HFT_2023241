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
    public class CustomerController : ControllerBase
    {
        ICustomerLogic logic;
        IHubContext<SignalRHub> hub;
        public CustomerController(ICustomerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Customer> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Customer Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Customer value)
        {
            logic.Create(value);
            hub.Clients.All.SendAsync("CustomerCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Customer value)
        {
            logic.Update(value);
            hub.Clients.All.SendAsync("CustomerUpdated", value);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var value = logic.Read(id);
            logic.Delete(id);
            hub.Clients.All.SendAsync("CustomerDeleted", value);

        }
    }
}
