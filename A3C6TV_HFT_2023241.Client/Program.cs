using A3C6TV_HFT_2023241.Logic;
using A3C6TV_HFT_2023241.Repository;

namespace A3C6TV_HFT_2023241.Client
{
    internal class Program
    {


        static void List(string entity)
        {

        }
        static void Create(string entity)
        {

        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            var ctx = new TajfunDBContext();

            var bookingRepo = new BookingRepository(ctx);
            var customerRepo = new CustomerRepository(ctx);
            var pooltableRepo = new PoolTableRepository(ctx);

            var bookingLogic = new BookingLogic(bookingRepo);
            var customerLogic = new CustomerLogic(customerRepo);
            var pooltableLogic = new PoolTableLogic(pooltableRepo);

        }
    }
}
