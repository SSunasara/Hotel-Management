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
    public class RoomManager : IRoomManager
    {
        IRoomRepository Repository;

        public RoomManager(IRoomRepository roomRepository)
        {
            Repository = roomRepository;
        }
        public bool Create(RoomViewModel roomViewModel)
        {
            roomViewModel.CreatedDate = DateTime.Now;
            return Repository.Create(roomViewModel);
        }

        public bool Delete(int id)
        {
            return Repository.Delete(id);
        }

        public List<RoomViewModel> GetFilteredRoom(string city, string pin, int? price, int? category)
        {
            return Repository.GetFilteredRoom(city, pin, price, category);
        }

        public List<RoomViewModel> GetRoomByHotelId(int id)
        {
            return Repository.GetRoomByHotelId(id);
        }

        public RoomViewModel GetRoomById(int id)
        {
            return Repository.GetRoomById(id);
        }

        public List<RoomViewModel> GetRooms()
        {
            return Repository.GetRooms();
        }

        public bool Update(RoomViewModel roomViewModel)
        {
            roomViewModel.Updateddate = DateTime.Now;
            return Repository.Update(roomViewModel);
        }
    }
}
