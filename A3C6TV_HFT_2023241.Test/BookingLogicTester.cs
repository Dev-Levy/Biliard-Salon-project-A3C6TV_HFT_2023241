using A3C6TV_HFT_2023241.Logic;
using A3C6TV_HFT_2023241.Models;
using A3C6TV_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace A3C6TV_HFT_2023241.Test
{
    [TestFixture]
    public class BookingLogicTester
    {
        BookingLogic bookingLogic;
        Mock<IRepository<Booking>> mockBookingRepo;

        [SetUp]
        public void Init()
        {
            mockBookingRepo = new Mock<IRepository<Booking>>();
            mockBookingRepo.Setup(m => m.ReadAll()).Returns(new List<Booking>()
            {
                new Booking(1,"2000.10.22 15:30","2000.10.22 16:30",1,1),
                new Booking(2,"2000.10.22 15:30","2000.10.22 16:30",2,2),
                new Booking(3,"2000.10.22 16:30","2000.10.22 18:30",1,3),
                new Booking(4,"2000.10.22 16:30","2000.10.22 19:00",2,4),
                new Booking(5,"2000.10.22 11:00","2000.10.22 15:00",3,5),
            }.AsQueryable);
            bookingLogic = new BookingLogic(mockBookingRepo.Object);
        }
    }
}
