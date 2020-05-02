using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Entity.ViewModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public Nullable<int> RoomId { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public Nullable<int> StatusOfBookingId { get; set; }
        public string status { get; set; }
    }
}
