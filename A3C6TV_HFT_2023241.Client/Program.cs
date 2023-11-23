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

        //ki kell dolgozni az összes crud metódust
        static void Create(string entity)
        {
            if (entity == "Bookings")
            {

            }
            else if (entity == "Customers")
            {
            }
            else if (entity == "PoolTables")
            {
            }
        }
        static void List(string entity)
        {
            if (entity == "Bookings")
            {
                Console.WriteLine("All Bookings: ");
                List<Booking> all = rest.Get<Booking>("tajfun");
                foreach (Booking booking in all)
                {
                    Console.WriteLine(booking.ToString());
                }
            }
            else if (entity == "Customers")
            {
                Console.WriteLine("All Customers: ");
                List<Customer> all = rest.Get<Customer>("tajfun");
                foreach (Customer cust in all)
                {
                    Console.WriteLine(cust.ToString());
                }
            }
            else if (entity == "PoolTables")
            {
                Console.WriteLine("All PoolTables: ");
                List<PoolTable> all = rest.Get<PoolTable>("tajfun");
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
            }
            else if (entity == "Customers")
            {
            }
            else if (entity == "PoolTables")
            {
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Bookings")
            {

            }
            else if (entity == "Customers")
            {
            }
            else if (entity == "PoolTables")
            {
            }
        }
        static void Main(string[] args)
        {
            RestService rest = new RestService("http://localhost:7332/", "tajfun");

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
