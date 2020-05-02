using HotelManagement.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Manager.Interface
{
    public interface IBookingManager
    {
        List<BookingViewModel> GetBooking();
        bool ChechAvailablity(int id, DateTime date);
        bool CreateBooking(int id, DateTime date);
        bool UpdateBookingDate(int id, DateTime date);
        bool UpdateBookingStatus(int id, int status);
        bool DeleteBooking(int id);
    }
}
