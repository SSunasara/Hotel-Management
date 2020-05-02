using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DataAccess.Repository;
using HotelManagement.DataAccess.Repository.Interface;
using Unity.Extension;
using Unity;

namespace HotelManagement.Business.Helper
{
    public class UnityResolver : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IHotelRepository, HotelRepository>();
            Container.RegisterType<IRoomRepository, RoomRepository>();
            Container.RegisterType<IBookingRepository, BookingRepository>();
        }
    }
}
