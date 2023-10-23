using A3C6TV_HFT_2023241.Models;
using A3C6TV_HFT_2023241.Repository;
using System;
using System.Linq;

namespace A3C6TV_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello github!");

            IRepository<Booking> repository = new BookingRepository(new TajfunDBContext());

            var items = repository.ReadAll().ToArray();

            Console.ReadKey();
        }
    }
}
