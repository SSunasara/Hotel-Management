using HotelManagement.DataAccess.Repository;
using HotelManagement.Entity.ViewModels;
using HotelManagement.Business.Manager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using HotelManagement.API.AuthHelper;

namespace HotelManagement.API.Controllers
{
    [BasicAuthentication]
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    [RoutePrefix("api/hotel")]
    public class HotelController : ApiController
    {
        IHotelManager hotelManager;

        public HotelController(IHotelManager _hotelManager)
        {
            hotelManager = _hotelManager;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAllHotels()
        {
            List<HotelViewModel> hotels = hotelManager.GetHotels();
            if (hotels == null)
                return Ok("Data not available");
            return Ok(hotels);
        }

        [Route("create")]
        [HttpPost]
        public IHttpActionResult Create(HotelViewModel hotel)
        {
            if (hotelManager.Create(hotel))
                return Ok("Hotel Data Inserted Successfully");
            return Ok("Something Went wrong, Data not Inserted");
        }

        [Route("update")]
        [HttpPut]
        public IHttpActionResult Update(HotelViewModel hotel)
        {            
            if(hotelManager.Update(hotel))
                return Ok("Hotel Detail Updated Successfully!!!");
            return Ok("Something Went wrong, Data not updated");
        }

        [Route("{id:int}/delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (hotelManager.Delete(id))
                return Ok("Room Deleted Successfully");
            return Ok("No Room available with id " + id);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            HotelViewModel hotel = hotelManager.GetHotelById(id);
            if(hotel == null)
                return Ok("No Hotel available with id " + id);
            return Ok(hotel);
        }
    }
}
