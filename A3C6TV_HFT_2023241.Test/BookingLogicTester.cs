using A3C6TV_HFT_2023241.Logic;
using A3C6TV_HFT_2023241.Models;
using A3C6TV_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
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
            var inputBookings = new List<Booking>()
            {
                new Booking(7, "2023-11-20 19:00", "2023-11-20 20:30", 9, 6),
                new Booking(8, "2023-11-21 07:30", "2023-11-21 13:30", 12, 6),
                new Booking(9, "2023-11-22 12:30", "2023-11-22 16:00", 3, 6),
                new Booking(10, "2023-11-23 04:30", "2023-11-23 10:00", 18, 7),
                new Booking(11, "2023-11-24 14:00", "2023-11-24 15:30", 1, 10),
                new Booking(12, "2023-11-25 12:00", "2023-11-25 17:00", 7, 8),
                new Booking(13, "2023-11-26 09:30", "2023-11-26 12:00", 6, 5),
                new Booking(14, "2023-11-27 01:00", "2023-11-27 14:30", 2, 4),
                new Booking(15, "2023-11-28 18:30", "2023-11-28 19:00", 16, 9),
                new Booking(16, "2023-11-29 10:00", "2023-11-29 12:30", 14, 11),
            }.AsQueryable();


            mockBookingRepo = new Mock<IRepository<Booking>>();
            mockBookingRepo.Setup(m => m.ReadAll()).Returns(inputBookings);


            bookingLogic = new BookingLogic(mockBookingRepo.Object);
        }

        [Test]
        public void HowManyBookingsBetweenTwoDatesWhereStartIsLaterThanEndThrowsException()
        {
            Assert.That(() => bookingLogic
            .HowManyBookingsBetweenTwoDates(new DateTime(2025, 01, 01),
                                            new DateTime(2020, 01, 01)),
                                            Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void HowManyBookingsBetweenTwoDatesWhereDatesAreFarApartReturnsAll()
        {
            int expected = bookingLogic.ReadAll().Count();

            var result = bookingLogic.HowManyBookingsBetweenTwoDates(new DateTime(2020, 11, 20), new DateTime(2025, 11, 20));

            Assert.That(result, Is.EqualTo(expected));
        }


        [Test]
        public void BookingsBetweenTwoDatesWhereStartIsLaterThanEndThrowsException()
        {
            Assert.That(() => bookingLogic
            .BookingsBetweenTwoDates(new DateTime(2025, 01, 01),
                                     new DateTime(2020, 01, 01)),
                                     Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void BookingsBetweenTwoDatesWhereStartIsEqualWithEndThrowsException()
        {
            Assert.That(() => bookingLogic
            .BookingsBetweenTwoDates(new DateTime(2023, 11, 20, 19, 00, 00),
                                     new DateTime(2023, 11, 20, 19, 00, 00)),
                                     Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void BookingsBetweenTwoDatesWhereDatesAreFarApartReturnsAll()
        {
            var expected = bookingLogic.ReadAll();

            var result = bookingLogic.BookingsBetweenTwoDates(new DateTime(2020, 11, 20), new DateTime(2025, 11, 20));

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void MostFrequentCustomersWithZeroParameterThrowsException()
        {
            var parameter = 0;
            Assert.That(() => bookingLogic.MostFrequentCustomers(parameter),
                                        Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void MostFrequentCustomersWithNegativeParameterThrowsException()
        {
            var parameter = -2;
            Assert.That(() => bookingLogic.MostFrequentCustomers(parameter),
                                        Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void MostFrequentCustomersWithPositiveParameterReturnsFrequentors()
        {
            var parameter = 2;

            var expected = new List<Frequenter>()
            {
                //két vendég kell ide
                new Frequenter(),
                new Frequenter()
            };

            var result = bookingLogic.MostFrequentCustomers(parameter);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TableKindsBookedWhereStartIsLaterThanEnd()
        {
            Assert.That(() => bookingLogic
                  .TablekindsBooked(new DateTime(2025, 01, 01),
                                    new DateTime(2020, 01, 01)),
                                    Throws.TypeOf<ArgumentException>());
        }



    }
}
