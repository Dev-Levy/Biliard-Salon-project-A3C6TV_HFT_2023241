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

        static void Create(string entity)
        {
            if (entity == "Bookings")
            {
                var bk = new Booking();
                Console.WriteLine("What's the startdate?");
                bk.StartDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("What's the enddate?");
                bk.EndDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Which table are you booking? [Id]");
                bk.TableId = int.Parse(Console.ReadLine());
                Console.WriteLine("Which customer is booking? [Id]");
                bk.CustomerId = int.Parse(Console.ReadLine());

                rest.Post(bk, "booking");
            }
            else if (entity == "Customers")
            {
                var cust = new Customer();
                Console.WriteLine("What's his/her name?");
                cust.Name = Console.ReadLine();
                Console.WriteLine("What's his/her phone number?");
                cust.Phone = Console.ReadLine();
                Console.WriteLine("What's his/her email?");
                cust.Email = Console.ReadLine();

                rest.Post(cust, "customer");
            }
            else if (entity == "PoolTables")
            {
                var table = new PoolTable();
                Console.WriteLine("Is it a pool or a snooker table?");
                table.T_kind = Console.ReadLine();

                rest.Post(table, "pooltable");
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

        //update-nél a httprequest nem kap eredményt
        static void Update(string entity)
        {
            if (entity == "Bookings")
            {
                Console.Write("Give me an ID: ");
                var ID = int.Parse(Console.ReadLine());
                Booking bk = rest.Get<Booking>(ID, "booking");
                Console.WriteLine(bk.ToString());
                string answer = "";
                while (answer != "no")
                {
                    Console.WriteLine();
                    Console.WriteLine("What do you want to update? - [StartDate/EndDate/TableId/CustomerId]");
                    Console.WriteLine("Type 'no', if you want to quit");
                    answer = Console.ReadLine().ToLower();
                    switch (answer)
                    {
                        case "startdate":
                            Console.Write("Enter a new StartDate: ");
                            bk.StartDate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("StartDate updated!");
                            break;
                        case "enddate":
                            Console.Write("Enter a new EndDate: ");
                            bk.EndDate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("EndDate updated!");
                            break;
                        case "tableid":
                            Console.Write("Enter a new TableId: ");
                            bk.TableId = int.Parse(Console.ReadLine());
                            Console.WriteLine("TableId updated!");
                            break;
                        case "customerid":
                            Console.Write("Enter a new CustomerId: ");
                            bk.CustomerId = int.Parse(Console.ReadLine());
                            Console.WriteLine("CustomerId updated!");
                            break;
                    }
                }
                rest.Put(bk, "booking");
                Console.ReadLine();
            }
            else if (entity == "Customers")
            {
                Console.Write("Give me an ID: ");
                var ID = int.Parse(Console.ReadLine());
                Customer cust = rest.Get<Customer>(ID, "customer");
                Console.WriteLine(cust.ToString());
                string answer = "";
                while (answer != "no")
                {
                    Console.WriteLine();
                    Console.WriteLine("What do you want to update? - [Name/Phone/Email]");
                    Console.WriteLine("Type 'no', if you want to quit");
                    answer = Console.ReadLine().ToLower();
                    switch (answer)
                    {
                        case "name":
                            Console.Write("Enter a new name: ");
                            cust.Name = Console.ReadLine();
                            Console.WriteLine("Name updated!");
                            break;
                        case "phone":
                            Console.Write("Enter a new phone number: ");
                            cust.Phone = Console.ReadLine();
                            Console.WriteLine("Phone number updated!");
                            break;
                        case "email":
                            Console.Write("Enter a new email: ");
                            cust.Email = Console.ReadLine();
                            Console.WriteLine("Email updated!");
                            break;
                    }
                }
                rest.Put(cust, "customer");
                Console.ReadLine();
            }
            else if (entity == "PoolTables")
            {
                Console.Write("Give me an ID: ");
                var ID = int.Parse(Console.ReadLine());
                PoolTable table = rest.Get<PoolTable>(ID, "pooltable");
                Console.WriteLine(table.ToString());


                string answer = "";
                Console.WriteLine("Is it a pool or a snooker table?");
                answer = Console.ReadLine().ToLower();

                switch (answer)
                {
                    case "pool":
                        table.T_kind = "pool";
                        break;
                    case "snooker":
                        table.T_kind = "snooker";
                        break;
                }
                Console.WriteLine("Table updated!");

                rest.Put(table, "customer");
                Console.ReadLine();
            }
        }

        //Delete-nél a httprequest nem kap eredményt
        static void Delete(string entity)
        {
            if (entity == "Bookings")
            {
                Console.Write("ID:");
                int ID = int.Parse(Console.ReadLine());
                rest.Delete(ID, "booking");
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
