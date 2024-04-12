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
            if (item.CustomerId < 1 || item.TableId < 1)
                throw new ArgumentException("Ids must be higher than zero!");

            repo.Create(item);
        }
        public void Delete(int id)
        {
            if (repo.Read(id) == null)
            {
                throw new ArgumentException("Booking with this ID doesn't exist! Cannot delete it!");
            }
            repo.Delete(id);
        }
        public Booking Read(int id)
        {
            if (repo.Read(id) == null)
            {
                throw new ArgumentException("Customer with this ID doesn't exist! Cannot read it!");
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
                throw new ArgumentException("Booking with this ID doesn't exist! Cannot update it!");
            }
            repo.Update(item);
        }

        public IEnumerable<Frequenter> MostFrequentCustomers(int numOfPeople)
        {
            if (numOfPeople < 1)
            {
                throw new ArgumentException("The number of people you searched is less than 1, you won't have any results!");
            }
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
            if (start >= end)
            {
                throw new ArgumentException("The starting date is later than/or at the same time as the ending date, you won't have any results!");
            }
            var count = repo.ReadAll()
                             .Where(t => t.StartDate >= start && t.EndDate <= end);

            return count.Count();
        }

        public IEnumerable<Booking> BookingsBetweenTwoDates(DateTime start, DateTime end)
        {
            if (start >= end)
            {
                throw new ArgumentException("The starting date is later than/or at the same time as the ending date, you won't have any results!");
            }
            var bookingList = repo.ReadAll()
                                  .Where(t => t.StartDate >= start
                                           && t.EndDate <= end);

            return bookingList.ToList();
        }

        public IEnumerable<PoolTable> MostUsedTable()
        {
            //groupby nem mindig működik linq 
            var poolTable = repo.ReadAll().AsEnumerable()
                                .GroupBy(t => t.TableId)
                                .OrderByDescending(t => t.Count())
                                .First()
                                .Select(t => t.PoolTable)
                                .Distinct();

            return poolTable;
        }

        public TableRate TablekindsBooked(DateTime start, DateTime end)
        {
            if (start >= end)
            {
                throw new ArgumentException("The starting date is later than/or at the same time as the ending date, you won't have any results!");
            }
            var tableRate = new TableRate()
            {
                PoolsBookedNum = repo.ReadAll().Where(t => t.PoolTable.T_kind == "pool" && t.StartDate >= start && t.EndDate <= end).Count(),
                SnookersBookedNum = repo.ReadAll().Where(t => t.PoolTable.T_kind == "snooker" && t.StartDate >= start && t.EndDate <= end).Count()
            };

            return tableRate;
        }
    }

}
