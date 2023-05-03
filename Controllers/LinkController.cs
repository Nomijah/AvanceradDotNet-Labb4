using Microsoft.AspNetCore.Mvc;


namespace AvanceradDotNet_Labb4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        // GET: api/<LinkController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LinkController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LinkController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LinkController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LinkController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
