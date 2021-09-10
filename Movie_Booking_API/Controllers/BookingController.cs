using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movie_Booking_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace Movie_Booking_API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApiContext _context;

        public BookingController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet("AllBookings")]
        public IActionResult Get()
        {
            var bookings = _context.Bookings
                .ToArray();

            return new JsonResult(bookings);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody] Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return Ok("Add success");
        }

        [HttpDelete("Delete")]
        public IActionResult Del([FromBody] Booking booking)
        {
            _context.Bookings.Remove(booking);
            _context.SaveChanges();

            return Ok("Delete success");
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();

            return Ok("Update success");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var bookings = _context.Bookings.ToArray();
            var res = bookings.First(b => b.Id == id);

            return new JsonResult(res);
        }

    }
}
