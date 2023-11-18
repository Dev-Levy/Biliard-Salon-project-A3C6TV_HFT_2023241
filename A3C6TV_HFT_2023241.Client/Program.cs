using A3C6TV_HFT_2023241.Logic;
using A3C6TV_HFT_2023241.Repository;
using System;

namespace A3C6TV_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var ctx = new TajfunDBContext();

                var bookingRepo = new BookingRepository(ctx);
                var customerRepo = new CustomerRepository(ctx);
                var pooltableRepo = new PoolTableRepository(ctx);

                var bookingLogic = new BookingLogic(bookingRepo);
                var customerLogic = new CustomerLogic(customerRepo);
                var pooltableLogic = new PoolTableLogic(pooltableRepo);



                DateTime start = new DateTime(2023, 11, 20, 10, 00, 00);
                DateTime end = new DateTime(2023, 12, 1, 20, 00, 00);

                //var frequentcust = bookingLogic.MostFrequentCustomers(5);
                //var number = bookingLogic.HowManyBookingsBetweenTwoDates(start, end);
                //var b_list = bookingLogic.BookingsBetweenTwoDates(start, end);
                //var table = bookingLogic.MostUsedTable();
                //var rate = bookingLogic.TablekindsBooked();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
