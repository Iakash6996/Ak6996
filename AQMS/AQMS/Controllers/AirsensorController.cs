using AQMS.Data;
using AQMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AQMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirsensorController : ControllerBase
    {
        private AirsensorDbContext _dbContext;
        
        public AirsensorController(AirsensorDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }
            // GET: api/<AirsensorController>
            [HttpGet]
            public IEnumerable<Airsensor> Get()
            {
                return _dbContext.Airsensors;
            }

        // GET api/<AirsensorController>/5
        [HttpGet("{id}")]
        public Airsensor Get(int id)
        {
            var Airsensor = _dbContext.Airsensors.Find(id);
            return Airsensor;
        }

        // POST api/<AirsensorController>
        [HttpPost]
        public IActionResult Post([FromBody] Airsensor airsensor)
        {
             _dbContext.Airsensors.Add(airsensor);
             _dbContext.SaveChanges();
              return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<AirsensorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Airsensor airsensorobj)
        {
            var Airsensor =_dbContext.Airsensors.Find(id);
                Airsensor.SensorId = airsensorobj.SensorId;
                Airsensor.FloorNo = airsensorobj.FloorNo;
                Airsensor.O2 = airsensorobj.O2;
                Airsensor.CO2 = airsensorobj.CO2;
                Airsensor.SO2 = airsensorobj.SO2;
                Airsensor.CO = airsensorobj.CO;
                Airsensor.C = airsensorobj.C;
                
                _dbContext.SaveChanges();
                return Ok("Record Updated Successfully");
            


        }


        // DELETE api/<AirsensorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Airsensor = _dbContext.Airsensors.Find(id);
                _dbContext.Airsensors.Remove(Airsensor);
                _dbContext.SaveChanges();
                return Ok("Record Deleted Successfully");
            
        }
    }
}
