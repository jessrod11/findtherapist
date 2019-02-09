using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindTherapist.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindTherapist.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TherapistController : ControllerBase
    {
        DatabaseInterface _db;
        TherapistStorage _therapist;

        public TherapistController(DatabaseInterface db)
        {
            _db = db;
            _therapist = new TherapistStorage(db);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allTherapists = _therapist.GetAllTherapists();
            return Ok(allTherapists);
        }

        [HttpGet("some")]
        public IActionResult GetSome()
        {
            var someTherapists = _therapist.GetSomeTherapists();
            return Ok(someTherapists);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleById(int id)
        {
            var singleTherapist = _therapist.GetSingleTherapist(id);
            return Ok(singleTherapist);
        }

        [HttpGet("{specialty}")]
        public IActionResult GetBySpecialty(string Specialty)
        {
            var specificTherapist = _therapist.GetSpecialty(Specialty);
            return Ok(specificTherapist);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var therapist = _therapist.GetSingleTherapist(id);

            if (therapist == null)
            {
                return NotFound();
            }

            var success = _therapist.DeleteById(id);

            if (success)
            {
                return Ok();
            }

            return BadRequest(new { Message = "Delete was unsuccessful" });
        }
    }
}