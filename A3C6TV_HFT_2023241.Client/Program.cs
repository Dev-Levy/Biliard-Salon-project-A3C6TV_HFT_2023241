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


                var asd = bookingLogic.NumberOfBookings();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
