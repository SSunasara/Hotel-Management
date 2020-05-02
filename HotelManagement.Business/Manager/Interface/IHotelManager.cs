using HotelManagement.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Business.Manager.Interface
{
    public interface IHotelManager
    {
        List<HotelViewModel> GetHotels();
        HotelViewModel GetHotelById(int id);
        bool Create(HotelViewModel hotelViewModel);
        bool Update(HotelViewModel hotelViewModel);
        bool Delete(int id);
    }
}
