using A3C6TV_HFT_2023241.Logic;
using A3C6TV_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace A3C6TV_HFT_2023241.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        IBookingLogic logic;

        public BookingController(IBookingLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Update([FromBody] Booking value)
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
