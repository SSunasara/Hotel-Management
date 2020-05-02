using HotelManagement.Business.Manager.Interface;
using HotelManagement.DataAccess.Repository.Interface;
using HotelManagement.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Manager
{
    public class BookingManager : IBookingManager
    {
        IBookingRepository Repository;
        public BookingManager(IBookingRepository _bookingRepository)
        {
            Repository = _bookingRepository;
        }

        public bool ChechAvailablity(int id, DateTime date)
        {
            return Repository.ChechAvailablity(id, date);
        }

        public bool CreateBooking(int id, DateTime date)
        {
            return Repository.CreateBooking(id,date);
        }

        public bool DeleteBooking(int id)
        {
            return Repository.DeleteBooking(id);
        }

        public List<BookingViewModel> GetBooking()
        {
            return Repository.GetBooking();
        }

        public bool UpdateBookingDate(int id, DateTime date)
        {
            return Repository.UpdateBookingDate(id, date);
        }

        public bool UpdateBookingStatus(int id, int status)
        {
            return Repository.UpdateBookingStatus(id, status);
        }
    }
}
