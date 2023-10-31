using A3C6TV_HFT_2023241.Models;
using A3C6TV_HFT_2023241.Repository;
using System;
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


        //Legtöbbet használt asztal


        //longest time customer


        //bookings between two dates


        // még egy non-crud method XD
    }
}
