using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTherapist.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public int TherapistId { get; set; }
        public int UserId { get; set; }
    }
}
