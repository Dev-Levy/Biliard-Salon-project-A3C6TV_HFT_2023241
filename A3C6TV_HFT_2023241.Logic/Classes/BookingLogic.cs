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

        public IEnumerable<BookingsByName> MostFrequentCustomers(int numOfPeople)
        {
            var freqPeople = repo.ReadAll()
                                    .GroupBy(t => t.Customer.Name)
                                    .Select(t => new BookingsByName()
                                    {
                                        name = t.Key,
                                        count = t.Count()
                                    })
                                    .OrderByDescending(t => t.count)
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
                                 name = t.Customer.Name,
                                 start = t.StartDate,
                                 end = t.EndDate,
                                 table = t.PoolTable.T_kind
                             });

            return bookingList.ToList();
        }

        public IEnumerable<PoolTable> MostUsedTable()
        {
            //ez a Bookings repo, amiben van egy virtual PoolTable navigaton property
            var poolTable = repo.ReadAll()
                                .GroupBy(t => t.TableId)
                                .OrderByDescending(t => t.Count())
                                .First()
                                .Select(t => t.PoolTable);

            return poolTable.ToList();
        }

        public TableRate TablekindsBooked()
        {
            var tableRate = new TableRate()
            {
                PoolsBookedNum = repo.ReadAll().Where(t => t.PoolTable.T_kind == "pool").Count(),
                SnookersBookedNum = repo.ReadAll().Where(t => t.PoolTable.T_kind == "snooker").Count()
            };

            return tableRate;
        }
    }

}
