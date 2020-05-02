using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelManagement.Data.Database;
using HotelManagement.Entity.ViewModels;

namespace HotelManagement.DataAccess
{
    public class AutoMapperConfig
    {
        public IMapper mapper;
        public AutoMapperConfig()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<HotelViewModel, Hotel>();
                cfg.CreateMap<Hotel, HotelViewModel>();
                cfg.CreateMap<RoomViewModel, Room>();
                cfg.CreateMap<Room, RoomViewModel>();
                cfg.CreateMap<BookingViewModel, Booking>();
                cfg.CreateMap<Booking, BookingViewModel>();
            });
            mapper = config.CreateMapper();
        }
    }
}
