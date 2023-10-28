using A3C6TV_HFT_2023241.Logic;
using A3C6TV_HFT_2023241.Repository;
using ConsoleTools;
using System;

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
            var consumableRepo = new ConsumableRepository(ctx);
            var customerRepo = new CustomerRepository(ctx);
            var pooltableRepo = new PoolTableRepository(ctx);

            var bookingLogic = new BookingLogic(bookingRepo);
            var consumableLogic = new ConsumableLogic(consumableRepo);
            var customerLogic = new CustomerLogic(customerRepo);
            var pooltableLogic = new PoolTableLogic(pooltableRepo);

            var bookingsSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Booking"))
                .Add("Create", () => Create("Booking"))
                .Add("Delete", () => Delete("Booking"))
                .Add("Update", () => Update("Booking"))
                .Add("Exit", ConsoleMenu.Close);

            var consumablesSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Consumable"))
                .Add("Create", () => Create("Consumable"))
                .Add("Delete", () => Delete("Consumable"))
                .Add("Update", () => Update("Consumable"))
                .Add("Exit", ConsoleMenu.Close);

            var customerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Customer"))
                .Add("Create", () => Create("Customer"))
                .Add("Delete", () => Delete("Customer"))
                .Add("Update", () => Update("Customer"))
                .Add("Exit", ConsoleMenu.Close);

            var pooltableSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("PoolTable"))
                .Add("Create", () => Create("PoolTable"))
                .Add("Delete", () => Delete("PoolTable"))
                .Add("Update", () => Update("PoolTable"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 1)
                .Add("Bookings", () => bookingsSubMenu.Show())
                .Add("Consumables", () => consumablesSubMenu.Show())
                .Add("Customers", () => customerSubMenu.Show())
                .Add("PoolTables", () => pooltableSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
