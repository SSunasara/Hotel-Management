using HotelManagement.Business.Helper;
using HotelManagement.Business.Manager;
using HotelManagement.Business.Manager.Interface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace HotelManagement.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.AddNewExtension<UnityResolver>();

            container.RegisterType<IHotelManager, HotelManager>();
            container.RegisterType<IBookingManager, BookingManager>();
            container.RegisterType<IRoomManager, RoomManager>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}