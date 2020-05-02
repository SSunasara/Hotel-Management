using HotelManagement.Data.Database;
using HotelManagement.DataAccess.Repository.Interface;
using HotelManagement.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DataAccess.Repository
{
    public class BookingRepository : IBookingRepository
    {
        hmdbEntities db;
        AutoMapperConfig mapperConfig;

        public BookingRepository()
        {
            db = new hmdbEntities();
            mapperConfig = new AutoMapperConfig();
        }

        public bool ChechAvailablity(int id, DateTime date)
        {
            try
            {
                if (db.Bookings.Any(b => b.RoomId == id && b.BookingDate == date && b.StatusOfBookingId != 4))
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateBooking(int id, DateTime date)
        {
            try
            {
                db.Bookings.Add(new Booking()
                {
                    BookingDate = date,
                    RoomId = id,
                    StatusOfBookingId = 1
                });
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBooking(int id)
        {
            try
            {
                Booking booking = db.Bookings.FirstOrDefault(b => b.Id == id);
                booking.StatusOfBookingId = 4;
                db.Entry(booking).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public List<BookingViewModel> GetBooking()
        {
            try
            {
                return mapperConfig.mapper.Map<List<BookingViewModel>>
                    (db.Bookings.Include("StatusOfBooking").ToList());
            }
            catch
            {
                return null;
            }
        }

        public bool UpdateBookingDate(int id, DateTime date)
        {
            try
            {
                Booking booking = db.Bookings.FirstOrDefault(b => b.Id == id);
                if (booking.StatusOfBookingId != 4)
                {
                    booking.BookingDate = date;
                    db.Entry(booking).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                        return true;
                    return false;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateBookingStatus(int id, int status)
        {
            try
            {
                Booking booking = db.Bookings.FirstOrDefault(b => b.Id == id);
                if(booking.StatusOfBookingId != 4)
                {
                    booking.StatusOfBookingId = status;
                    db.Entry(booking).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                        return true;
                    return false;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
