using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTherapist.Models
{
    public class FavTherapist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TherapistId { get; set; }
    }
}
