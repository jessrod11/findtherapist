using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTherapist.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int TherapistId { get; set; }
        public int UserId { get; set; }
    }
}
