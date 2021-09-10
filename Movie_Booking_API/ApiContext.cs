using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie_Booking_API.Models;

namespace Movie_Booking_API
{
    public class ApiContext: DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
    }
}
