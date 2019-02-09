using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindTherapist.DataAccess;
using FindTherapist.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindTherapist.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        DatabaseInterface _db;
        ReviewStorage _review;

        public ReviewController(DatabaseInterface db)
        {
            _db = db;
            _review = new ReviewStorage(db);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleById(int id)
        {
            var singleReview = _review.GetSingleReview(id);
            return Ok(singleReview);
        }

        [HttpPost]
        public void AddAReview(Reviews review)
        {
            _review.Add(review);
        }

        [HttpPut]
        public IActionResult UpdateReview(Reviews r)
        {
            var success = _review.Edit(r);

            if (success)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var review = _review.GetSingleReview(id);

            if (review == null)
            {
                return NotFound();
            }

            var success = _review.DeleteById(id);

            if (success)
            {
                return Ok();
            }

            return BadRequest(new { Message = "Delete was unsuccessful" });
        }

    }
}