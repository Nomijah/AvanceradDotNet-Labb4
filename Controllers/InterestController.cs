using Microsoft.AspNetCore.Mvc;


namespace AvanceradDotNet_Labb4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        // GET: api/<InterestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InterestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InterestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InterestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InterestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
