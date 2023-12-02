using A3C6TV_HFT_2023241.Logic;
using A3C6TV_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace A3C6TV_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NonCrudController : ControllerBase
    {
        IBookingLogic logic;
        public NonCrudController(IBookingLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet("{num}")]
        public IEnumerable<Frequenter> MostFrequentCustomers(int num)
        {
            return logic.MostFrequentCustomers(num);
        }

        [HttpGet("{start},{end}")]
        public int HowManyBookingsBetweenTwoDates(DateTime start, DateTime end)
        {
            return logic.HowManyBookingsBetweenTwoDates(start, end);
        }

        [HttpGet("{start},{end}")]
        public IEnumerable<Booking> BookingsBetweenTwoDates(DateTime start, DateTime end)
        {
            return logic.BookingsBetweenTwoDates(start, end);
        }

        [HttpGet]
        public IEnumerable<PoolTable> MostUsedTable()
        {
            return logic.MostUsedTable();
        }

        [HttpGet("{start},{end}")]
        public TableRate TablekindsBooked(DateTime start, DateTime end)
        {
            return logic.TablekindsBooked(start, end);
        }
    }
}
