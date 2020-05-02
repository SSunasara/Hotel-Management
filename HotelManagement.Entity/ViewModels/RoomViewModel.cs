using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Entity.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public Nullable<int> HotelId { get; set; }
        public string RoomName { get; set; }
        public Nullable<int> RoomCategoryId { get; set; }
        public Nullable<int> RoomPrice { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> Updateddate { get; set; }
        public string UpdatedBy { get; set; }
        public HotelViewModel Hotel { get; set; }
    }
}
