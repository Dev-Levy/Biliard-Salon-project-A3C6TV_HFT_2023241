using A3C6TV_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace A3C6TV_HFT_2023241.Logic
{
    public interface IBookingLogic
    {
        void Create(Booking item);
        Booking Read(int id);
        IQueryable<Booking> ReadAll();
        void Update(Booking item);
        void Delete(int id);
        
        
        IEnumerable<BookingInfo> BookingsBetweenTwoDates(DateTime start, DateTime end);
        int HowManyBookingsBetweenTwoDates(DateTime start, DateTime end);
        IEnumerable<BookingsByName> MostFrequentCustomers(int numOfPeople);
        IEnumerable<PoolTable> MostUsedTable();
        TableRate TablekindsBooked();
    }
}