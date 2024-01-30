using A3C6TV_HFT_2023241.Logic;
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
            try
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
                    Console.WriteLine("Booking added!");
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
                    if (cust.Name == "")
                        throw new ArgumentException("Name is required!");


                    rest.Post(cust, "customer");
                    Console.WriteLine("Customer added!");
                }
                else if (entity == "PoolTables")
                {
                    var table = new PoolTable();
                    Console.WriteLine("Is it a pool or a snooker table?");
                    table.T_kind = Console.ReadLine();
                    if (table.T_kind=="")
                        throw new ArgumentException("This field is required!");

                    rest.Post(table, "pooltable");
                    Console.WriteLine("Pooltable added!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { Console.ReadLine(); }

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
            try
            {
                if (entity == "Bookings")
                {
                    Console.Write("Give me an ID: ");
                    var ID = int.Parse(Console.ReadLine());
                    Booking bk = rest.Get<Booking>(ID, "booking");

                    Console.WriteLine();
                    Console.WriteLine(bk.ToString());
                    Console.WriteLine();

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
                    rest.Delete(ID, "booking");
                    rest.Post(bk, "booking");
                    Console.WriteLine("Booking updated!");

                    //The put method is not allowed so I used the delete then post method instead
                    //not the right way, but it works

                    //rest.Put(bk, "booking");
                    Console.ReadLine();
                }
                else if (entity == "Customers")
                {
                    Console.Write("Give me an ID: ");
                    var ID = int.Parse(Console.ReadLine());
                    Customer cust = rest.Get<Customer>(ID, "customer");
                    Console.WriteLine();
                    Console.WriteLine(cust.ToString());
                    Console.WriteLine();

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
                    rest.Delete(ID, "customer");
                    rest.Post(cust, "customer");
                    Console.WriteLine("Customer updated!");

                    //The put method is not allowed so I used the delete then post method instead
                    //not the right way, but it works

                    //rest.Put(cust, "customer");
                    Console.ReadLine();
                }
                else if (entity == "PoolTables")
                {
                    Console.Write("Give me an ID: ");
                    var ID = int.Parse(Console.ReadLine());
                    PoolTable table = rest.Get<PoolTable>(ID, "pooltable");
                    Console.WriteLine();
                    Console.WriteLine(table.ToString());
                    Console.WriteLine();


                    string answer = "";
                    Console.WriteLine("Is it a pool or a snooker table?");
                    answer = Console.ReadLine().ToLower();
                    if (answer == "")
                    {
                        throw new ArgumentException("This field is required!");
                    }
                    switch (answer)
                    {
                        case "pool":
                            table.T_kind = "pool";
                            break;
                        case "snooker":
                            table.T_kind = "snooker";
                            break;
                    }

                    rest.Put(table, "pooltable");
                    Console.WriteLine("Table updated!");
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { Console.ReadLine(); }

        }
        static void Delete(string entity)
        {
            try
            {
                if (entity == "Bookings")
                {
                    Console.Write("ID:");
                    int ID = int.Parse(Console.ReadLine());
                    rest.Delete(ID, "booking");
                    Console.WriteLine("Booking deleted!");
                }
                else if (entity == "Customers")
                {
                    Console.Write("ID:");
                    int ID = int.Parse(Console.ReadLine());
                    rest.Delete(ID, "customer");
                    Console.WriteLine("Customer deleted!");
                }
                else if (entity == "PoolTables")
                {
                    Console.Write("ID:");
                    int ID = int.Parse(Console.ReadLine());
                    rest.Delete(ID, "pooltable");
                    Console.WriteLine("Table deleted!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { Console.ReadLine(); }

        }

        static void MostFrequentCustomers(string entity)
        {
            try
            {
                Console.WriteLine("How many frequent customers do you want to list?");
                int numofppl = int.Parse(Console.ReadLine());

                var custs = rest.GetMostFrequentCustomers<Frequenter>(numofppl, entity);
                foreach (Frequenter cust in custs)
                {
                    Console.WriteLine(cust.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { Console.ReadLine(); }
        }
        static void HowManyBookingsBetweenTwoDates(string entity)
        {
            try
            {
                Console.WriteLine("What's the startdate?");
                var start = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("What's the enddate?");
                var end = DateTime.Parse(Console.ReadLine());

                var num = rest.GetHowManyBookingsBetweenTwoDates<int>(start, end, entity);
                Console.WriteLine(num);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { Console.ReadLine(); }
        }
        static void BookingsBetweenTwoDates(string entity)
        {
            try
            {
                Console.WriteLine("What's the startdate?");
                var start = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("What's the enddate?");
                var end = DateTime.Parse(Console.ReadLine());

                var bks = rest.GetBookingsBetweenTwoDates<Booking>(start, end, entity);
                foreach (Booking bk in bks)
                {
                    Console.WriteLine(bk.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { Console.ReadLine(); }

        }
        static void MostUsedTable(string entity)
        {
            try
            {
                var table = rest.GetMostUsedTable<PoolTable>(entity);
                foreach (PoolTable t in table)
                {
                    Console.WriteLine(t.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { Console.ReadLine(); }
        }
        static void TablekindsBooked(string entity)
        {
            try
            {
                Console.WriteLine("What's the startdate?");
                var start = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("What's the enddate?");
                var end = DateTime.Parse(Console.ReadLine());

                var rate = rest.GetTablekindsBooked<TableRate>(start, end, entity);
                Console.WriteLine(rate.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { Console.ReadLine(); }
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
            var noncrudSubMenu = new ConsoleMenu(args, level: 1)
                .Add("MostFrequentCustomers", () => MostFrequentCustomers("noncrud"))
                .Add("HowManyBookingsBetweenTwoDates", () => HowManyBookingsBetweenTwoDates("noncrud"))
                .Add("BookingsBetweenTwoDates", () => BookingsBetweenTwoDates("noncrud"))
                .Add("MostUsedTable", () => MostUsedTable("noncrud"))
                .Add("TablekindsBooked", () => TablekindsBooked("noncrud"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Bookings", () => bookingSubMenu.Show())
                .Add("Customers", () => customerSubMenu.Show())
                .Add("PoolTables", () => pooltableSubManu.Show())
                .Add("Non CRUDs", () => noncrudSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
