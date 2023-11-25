using A3C6TV_HFT_2023241.Models;
using ConsoleTools;
using MovieDbApp.RestClient;
using System;
using System.Collections.Generic;

namespace A3C6TV_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;

        //ki kell dolgozni a create és update metódust
        static void Create(string entity)
        {
            if (entity == "Bookings")
            {
                rest.Post(new Booking(), "booking");
            }
            else if (entity == "Customers")
            {
                rest.Post(new Customer(), "customer");
            }
            else if (entity == "PoolTables")
            {
                rest.Post(new PoolTable(), "pooltable");
            }
        }
        static void List(string entity)
        {
            if (entity == "Bookings")
            {
                Console.WriteLine("All Bookings: ");
                List<Booking> all = rest.Get<Booking>("booking");
                foreach (Booking booking in all)
                {
                    Console.WriteLine(booking.ToString());
                }
            }
            else if (entity == "Customers")
            {
                Console.WriteLine("All Customers: ");
                List<Customer> all = rest.Get<Customer>("customer");
                foreach (Customer cust in all)
                {
                    Console.WriteLine(cust.ToString());
                }
            }
            else if (entity == "PoolTables")
            {
                Console.WriteLine("All PoolTables: ");
                List<PoolTable> all = rest.Get<PoolTable>("pooltable");
                foreach (PoolTable table in all)
                {
                    Console.WriteLine(table.ToString());
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Bookings")
            {
                //rest.Put(_,"booking");
            }
            else if (entity == "Customers")
            {
                //rest.Put(_, "customer");
            }
            else if (entity == "PoolTables")
            {
                //rest.Put(_, "pooltable");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Bookings")
            {
                Console.Write("ID:");
                int ID = int.Parse(Console.ReadLine());
                rest.Delete(ID,"booking");
            }
            else if (entity == "Customers")
            {
                Console.Write("ID:");
                int ID = int.Parse(Console.ReadLine());
                rest.Delete(ID, "customers");
            }
            else if (entity == "PoolTables")
            {
                Console.Write("ID:");
                int ID = int.Parse(Console.ReadLine());
                rest.Delete(ID, "pooltables");
            }
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:7332/", "booking");

            var bookingSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Bookings"))
                .Add("Create", () => Create("Bookings"))
                .Add("Delete", () => Delete("Bookings"))
                .Add("Update", () => Update("Bookings"))
                .Add("Exit", ConsoleMenu.Close);

            var customerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Customers"))
                .Add("Create", () => Create("Customers"))
                .Add("Delete", () => Delete("Customers"))
                .Add("Update", () => Update("Customers"))
                .Add("Exit", ConsoleMenu.Close);

            var pooltableSubManu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("PoolTables"))
                .Add("Create", () => Create("PoolTables"))
                .Add("Delete", () => Delete("PoolTables"))
                .Add("Update", () => Update("PoolTables"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Bookings", () => bookingSubMenu.Show())
                .Add("Customers", () => customerSubMenu.Show())
                .Add("PoolTables", () => pooltableSubManu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}
