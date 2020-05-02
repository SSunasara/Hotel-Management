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
    public class HotelManager : IHotelManager
    {
        IHotelRepository Repository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            Repository = hotelRepository;
        }
        public bool Create(HotelViewModel hotelViewModel)
        {
            hotelViewModel.CreatedDate = DateTime.Now;
            return Repository.Create(hotelViewModel);
        }

        public bool Delete(int id)
        {
            return Repository.Delete(id);
        }

        public HotelViewModel GetHotelById(int id)
        {
            return Repository.GetHotelById(id);
        }

        public List<HotelViewModel> GetHotels()
        {
            return Repository.GetHotels();
        }

        public bool Update(HotelViewModel hotelViewModel)
        {
            hotelViewModel.Updateddate = DateTime.Now;
            return Repository.Update(hotelViewModel);
        }
    }
}
