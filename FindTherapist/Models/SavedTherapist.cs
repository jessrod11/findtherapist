using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTherapist.Models
{
    public class SavedTherapist
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Img { get; set; }
        public string Specialty { get; set; }
        public int TherapistId { get; set; }
    }
}
