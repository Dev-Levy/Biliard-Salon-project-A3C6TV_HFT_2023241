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
    public class BookingController : ControllerBase
    {
        IBookingLogic logic;
        IHubContext<SignalRHub> hub;

        public BookingController(IBookingLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Booking> ReadAll()
        {
            return logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Booking Read(int id)
        {
            return logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Booking value)
        {
            logic.Create(value);
            hub.Clients.All.SendAsync("BookingCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Booking value)
        {
            logic.Update(value);
            hub.Clients.All.SendAsync("BookingCreated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var value = logic.Read(id);
            logic.Delete(id);
            hub.Clients.All.SendAsync("BookingCreated", value);
        }
    }
}
