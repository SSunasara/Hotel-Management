using AutoMapper;
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
    public class HotelRepository : IHotelRepository
    {
        hmdbEntities db;
        AutoMapperConfig mapperConfig;
        
        public HotelRepository()
        {
            db = new hmdbEntities();
            mapperConfig = new AutoMapperConfig();
        }

        public List<HotelViewModel> GetHotels()
        {
            try
            {
                return mapperConfig.mapper.Map<List<HotelViewModel>>(db.Hotels.OrderBy(h=>h.HotelName).ToList());
            }
            catch
            {
                return null;
            }
            
        }

        public bool Create(HotelViewModel hotelViewModel)
        {
            try
            {
                db.Hotels.Add(mapperConfig.mapper.Map<Hotel>(hotelViewModel));
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
                db.Hotels.Remove(db.Hotels.FirstOrDefault(h => h.Id == id));
                if (db.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
            
        }

        public HotelViewModel GetHotelById(int id)
        {
            try
            {
                return mapperConfig.mapper.Map<HotelViewModel>(db.Hotels.FirstOrDefault(h => h.Id == id));
            }
            catch
            {
                return null;
            }
        }

        
        public bool Update(HotelViewModel hotelViewModel)
        {
            try
            {
                Hotel hotel = mapperConfig.mapper.Map<Hotel>(hotelViewModel);
                db.Entry(hotel).State = EntityState.Modified;
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
