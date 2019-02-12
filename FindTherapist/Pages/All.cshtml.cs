using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FindTherapist.Pages
{
    public class AllModel : PageModel
    {
        public string Message { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Img { get; set; }
        public string Specialty { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public long Phone { get; set; }
        public string Web { get; set; }
        public int UserId { get; set; }
        public int SavedId { get; set; }
        public int FavId { get; set; }
        public int ReviewId { get; set; }

        public void OnGet()
        {
            //Message = "Your application description page.";
        }
    }
}
