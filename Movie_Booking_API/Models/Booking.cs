using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Booking_API.Models
{
    public class Booking
    {
        public string Id { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public int Numbers_ofTickets { get; set; }

        public double Amount { get; set; }
    }
}
