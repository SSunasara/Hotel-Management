using HotelManagement.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DataAccess.Repository.Interface
{
    public interface IHotelRepository
    {
        List<HotelViewModel> GetHotels();
        HotelViewModel GetHotelById(int id);
        bool Create(HotelViewModel hotelViewModel);
        bool Update(HotelViewModel hotelViewModel);
        bool Delete(int id);
    }
}
