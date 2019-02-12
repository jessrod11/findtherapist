using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindTherapist.DataAccess;
using FindTherapist.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindTherapist.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedController : ControllerBase
    {
        DatabaseInterface _db;
        SavedStorage _saved;

        public SavedController(DatabaseInterface db)
        {
            _db = db;
            _saved = new SavedStorage(db);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allTherapists = _saved.GetAll();
            return Ok(allTherapists);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleById(int id)
        {
            var singleTherapist = _saved.GetSingleTherapist(id);
            return Ok(singleTherapist);
        }

        [HttpPost]
        public void SaveATherapist(SavedTherapist saved)
        {
            _saved.Add(saved);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var therapist = _saved.GetSingleTherapist(id);

            if (therapist == null)
            {
                return NotFound();
            }

            var success = _saved.DeleteById(id);

            if (success)
            {
                return Ok();
            }

            return BadRequest(new { Message = "Delete was unsuccessful" });
        }
    }
}