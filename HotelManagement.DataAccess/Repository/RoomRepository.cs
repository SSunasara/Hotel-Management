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
    public class RoomRepository: IRoomRepository
    {
        hmdbEntities db;
        AutoMapperConfig mapperConfig;

        public RoomRepository()
        {
            db = new hmdbEntities();
            mapperConfig = new AutoMapperConfig();
        }

        public bool Create(RoomViewModel roomViewModel)
        {
            try
            {
                db.Rooms.Add(mapperConfig.mapper.Map<Room>(roomViewModel));
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
            
        }

        public bool Delete(int id)
        {
            try
            {
                db.Rooms.Remove(db.Rooms.FirstOrDefault(r => r.Id == id));
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }                          
        }

        public List<RoomViewModel> GetFilteredRoom(string city, string pin, int? price, int? category)
        {
            var room = db.Rooms.Include("Hotel").AsQueryable();
            if (city != null)
                room = room.Where(r => r.Hotel.City == city).AsQueryable();
            if(pin != null)
                room = room.Where(r => r.Hotel.PinCode == pin).AsQueryable();
            if(price != null)
                room = room.Where(r => r.RoomPrice == price).AsQueryable();
            if(category != null)
                room = room.Where(r => r.RoomCategoryId == category).AsQueryable();

            return mapperConfig.mapper.Map<List<RoomViewModel>>(room.OrderBy(r=>r.RoomPrice).ToList());
        }

        public List<RoomViewModel> GetRoomByHotelId(int id)
        {
            try
            {
                return mapperConfig.mapper.Map<List<RoomViewModel>>(db.Rooms.Where(r => r.HotelId == id).ToList());
            }
            catch
            {
                return null;
            }
        }

        public RoomViewModel GetRoomById(int id)
        {
            try
            {
                return mapperConfig.mapper.Map<RoomViewModel>(db.Rooms.FirstOrDefault(r => r.Id == id));
            }
            catch
            {
                return null;
            }
            
        }

        public List<RoomViewModel> GetRooms()
        {
            try
            {
                return mapperConfig.mapper.Map<List<RoomViewModel>>(db.Rooms.ToList());
            }
            catch
            {
                return null;
            }
        }

        public bool Update(RoomViewModel roomViewModel)
        {
            try
            {
                db.Entry(mapperConfig.mapper.Map<Room>(roomViewModel)).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
