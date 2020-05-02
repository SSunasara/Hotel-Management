using HotelManagement.Business.Manager.Interface;
using HotelManagement.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HotelManagement.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/room")]
    public class RoomController : ApiController
    {
        IRoomManager roomManager;
        public RoomController(IRoomManager _roomManager)
        {
            roomManager = _roomManager;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllRooms()
        {
            List<RoomViewModel> rooms = roomManager.GetRooms();
            if (rooms == null)
                return Ok("Data not available");
            return Ok(rooms);
        }

        [Route("create")]
        [HttpPost]
        public IHttpActionResult Create(RoomViewModel room)
        {
            if (roomManager.Create(room))
                return Ok("Room Data Inserted Successfully");
            return Ok("Something Went wrong, Data not Inserted");
        }

        [Route("update")]
        [HttpPut]
        public IHttpActionResult Update(RoomViewModel room)
        {
            if (roomManager.Update(room))
                return Ok("Room Detail Updated Successfully!!!");
            return Ok("Something Went wrong, Data not updated");
        }

        [Route("{id:int}/delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (roomManager.Delete(id))
                return Ok("Room Deleted Successfully");
            return Ok("No Room available with id "+id);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            RoomViewModel room = roomManager.GetRoomById(id);
            if(room == null)
                return Ok("No Room available with id " + id);
            return Ok(room);
        }

        [Route("hotel/{id:int}")]
        [HttpGet]
        public IHttpActionResult GetRoomByHotelId(int id)
        {
            List<RoomViewModel> rooms = roomManager.GetRoomByHotelId(id);
            if(rooms.Count() > 0)           
                return Ok(rooms);
            return Ok("No Room available with id Hotel id " + id + ", Or might you give wrong id");
        }

        [Route("filteredroom")]
        [HttpGet]
        public IHttpActionResult GetFilteredRoom(string city, string pin, int? price, int? category)
        {
            List<RoomViewModel> rooms = roomManager.GetFilteredRoom(city, pin, price, category);
            if (rooms.Count() > 0)
                return Ok(rooms);
            return Ok("No Room available with id Given Filter");
        }
    }
}
