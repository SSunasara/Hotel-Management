using HotelManagement.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DataAccess.Repository.Interface
{
    public interface IRoomRepository
    {
        

        List<RoomViewModel> GetRooms();
        RoomViewModel GetRoomById(int id); 
        bool Create(RoomViewModel roomViewModel);
        bool Update(RoomViewModel roomViewModel);
        bool Delete(int id);
        List<RoomViewModel> GetRoomByHotelId(int id);
        List<RoomViewModel> GetFilteredRoom(string city, string pin, int? price, int? category);
    }
}
