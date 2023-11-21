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

        public IEnumerable<Frequenter> MostFrequentCustomers(int numOfPeople)
        {
            var freqPeople = repo.ReadAll()
                                    .GroupBy(t => t.Customer.Name)
                                    .Select(t => new Frequenter()
                                    {
                                        Name = t.Key,
                                        Count = t.Count()
                                    })
                                    .OrderByDescending(t => t.Count)
                                    .Take(numOfPeople);
            return freqPeople.ToList();
        }

        public int HowManyBookingsBetweenTwoDates(DateTime start, DateTime end)
        {
            var count = repo.ReadAll()
                             .Where(t => t.StartDate >= start && t.EndDate <= end);

            return count.Count();
        }

        public IEnumerable<BookingInfo> BookingsBetweenTwoDates(DateTime start, DateTime end)
        {
            var bookingList = repo.ReadAll()
                             .Where(t => t.StartDate >= start && t.EndDate <= end)
                             .Select(t => new BookingInfo
                             {
                                 Name = t.Customer.Name,
                                 Start = t.StartDate,
                                 End = t.EndDate,
                                 Table = t.PoolTable.T_kind
                             });

            return bookingList.ToList();
        }

        public IEnumerable<PoolTable> MostUsedTable()
        {
            //groupby nem mindig működik linq 
            var poolTable = repo.ReadAll().ToList()
                                .GroupBy(t => t.TableId)
                                .OrderByDescending(t => t.Count())
                                .First()
                                .Select(t => t.PoolTable)
                                .Distinct();

            return poolTable;
        }

        public TableRate TablekindsBooked(DateTime start, DateTime end)
        {
            var tableRate = new TableRate()
            {
                PoolsBookedNum = repo.ReadAll().Where(t => t.PoolTable.T_kind == "pool" && t.StartDate >= start && t.EndDate <= end).Count(),
                SnookersBookedNum = repo.ReadAll().Where(t => t.PoolTable.T_kind == "snooker" && t.StartDate >= start && t.EndDate <= end).Count()
            };

            return tableRate;
        }
    }

}
