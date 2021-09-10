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

        /// <summary>
        /// View All Bookings
        /// </summary>
        [HttpGet("AllBookings")]
        public IActionResult Get()
        {
            var bookings = _context.Bookings
                .ToArray();

            return new JsonResult(bookings);
        }

        /// <summary>
        /// Add booking from body data
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Add
        ///     {
        ///        "Id": "1a",
        ///        "Date": "09/10/2021",
        ///        "Time": "16:38",
        ///        "Numbers_ofTickets": 1,
        ///        "Amount": 7
        ///     }
        ///
        /// </remarks>
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return Ok("Add success");
        }

        /// <summary>
        /// Deletes a specific booking in body data.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /Delete
        ///     {
        ///        "Id": "1a",
        ///        "Date": "09/10/2021",
        ///        "Time": "16:38",
        ///        "Numbers_ofTickets": 1,
        ///        "Amount": 7
        ///     }
        ///
        /// </remarks>
        [HttpDelete("Delete")]
        public IActionResult Del([FromBody] Booking booking)
        {
            _context.Bookings.Remove(booking);
            _context.SaveChanges();

            return Ok("Delete success");
        }

        /// <summary>
        /// Update a specfic booking in body data
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Update
        ///     {
        ///        "Id": "1a",
        ///        "Date": "09/10/2021",
        ///        "Time": "16:38",
        ///        "Numbers_ofTickets": 1,
        ///        "Amount": 8
        ///     }
        ///
        /// </remarks>
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();

            return Ok("Update success");
        }

        /// <summary>
        /// Get a booking info by booking Id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var bookings = _context.Bookings.ToArray();
            var res = bookings.First(b => b.Id == id);

            return new JsonResult(res);
        }

    }
}
