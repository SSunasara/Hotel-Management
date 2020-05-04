using HotelManagement.API.AuthHelper;
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
    [BasicAuthentication]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/booking")]
    public class BookingController : ApiController
    {
        IBookingManager manager;
        public BookingController(IBookingManager _manager)
        {
            manager = _manager;
        }

        [Route("book")]
        [HttpPost]
        public IHttpActionResult Book(int roomId, DateTime date)
        {
            if (date < DateTime.Now)
                return Ok("You Must have to give future date");
            if (manager.ChechAvailablity(roomId, date))
            {
                if (manager.CreateBooking(roomId, date))
                    return Ok("Booking Successfully!!!");
                return Ok("Booking not Done, Something went wrog");
            }
            else
                return Ok("Your Requested Room is not Available for Given date");            
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<BookingViewModel> booking = manager.GetBooking();
            if (booking == null)
                return Ok("Data Not Available");
            return Ok(booking);
        }

        [Route("checkavailablity")]
        [HttpGet]
        public IHttpActionResult check(int roomId, DateTime date)
        {
            if (date < DateTime.Now)
                return Ok("You Must have to give future date");
            return Ok(manager.ChechAvailablity(roomId, date));
        }

        [Route("updateDate")]
        [HttpPut]
        public IHttpActionResult UpdateDate(int bookinId, DateTime newdate)
        {
            if (newdate < DateTime.Now)
                return Ok("You Must have to give future date");
            return Ok(manager.UpdateBookingDate(bookinId, newdate));
        }

        [Route("updateStatus")]
        [HttpPut]
        public IHttpActionResult UpdateStatus(int bookingId, int statusId)
        {            
            return Ok(manager.UpdateBookingStatus(bookingId, statusId));
        }

        [Route("delete/{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(manager.DeleteBooking(id));
        }

    }
}
