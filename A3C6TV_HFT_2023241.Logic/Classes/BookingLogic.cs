using A3C6TV_HFT_2023241.Models;
using A3C6TV_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace A3C6TV_HFT_2023241.Logic
{
    public class BookingLogic : IBookingLogic
    {
        IRepository<Booking> repo;

        public BookingLogic(IRepository<Booking> inrepo)
        {
            repo = inrepo;
        }
        public void Create(Booking item)
        {
            repo.Create(item);
        }
        public void Delete(int id)
        {
            if (repo.Read(id) == null)
            {
                throw new ArgumentException("Booking with this ID doesn't exist!\nCannot delete it!");
            }
            repo.Delete(id);
        }
        public Booking Read(int id)
        {
            if (repo.Read(id) == null)
            {
                throw new ArgumentException("Customer with this ID doesn't exist!\nCannot read it!");
            }
            return repo.Read(id);
        }
        public IQueryable<Booking> ReadAll()
        {
            if (repo.ReadAll().Count() == 0) //should I check for empty repo? 
                throw new ArgumentException("There are no bookings is the repository!");

            return repo.ReadAll();
        }
        public void Update(Booking item)
        {
            if (repo.Read(item.BookingId) == null)
            {
                throw new ArgumentException("Booking with this ID doesn't exist!\nCannot update it!");
            }
            repo.Update(item);
        }

        //5-nél többször foglaló vendég - Törzsvedégek
        public IEnumerable<Customer> Frequenters()
        {
            var people = repo.ReadAll()
                        .GroupBy(b => b.CustomerId)
                        .Where(g => g.Count() > 5);   // i don't get how LINQ-s work

            //hogyan szedek ki customer egyedeket booking egyedekből az ID segítségével

            return people;
        }

        //Legtöbbet használt asztalok
        public IEnumerable<Booking> MostUsedTables()
        {
            var tables = from x in repo.ReadAll()
                         group x by x.TableId into g
                         orderby g.Count()
                         select g.First(); //Take(3)

            return tables;
            //hogyan kéne IEnumerable-re kasztolni?
        }

        //longest time customer


        //bookings between two dates


        // még egy non-crud method XD
    }
}
