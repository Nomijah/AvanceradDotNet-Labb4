using AvanceradDotNet_Labb4.Models;
using AvanceradDotNet_Labb4.Services;
using Microsoft.AspNetCore.Mvc;


namespace AvanceradDotNet_Labb4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private ILabb4<Person> _personRepo;
        private ILabb4<Link> _linkRepo;
        private ILabb4<Interest> _interestRepo;
        public PersonController(ILabb4<Person> personRepo, ILabb4<Link> linkRepo, ILabb4<Interest> interestRepo)
        {
            _personRepo = personRepo;
            _linkRepo = linkRepo;
            _interestRepo = interestRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personRepo.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var result = _personRepo.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Person with id : {id} not found.");
        }

        [HttpGet("Links")]
        public IActionResult GetLinks(int id)
        {
            var links = _linkRepo.GetAll();
            var result = new List<Link>();
            foreach (var link in links)
            {
                if (link.PersonId == id)
                {
                    result.Add(link);
                }
            }
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Person with id : {id} not found.");
        }

        [HttpGet("Interests")]
        public IActionResult GetInterests(int id)
        {
            var interests = _interestRepo.GetAll();
            var result = new List<Interest>();
            foreach (var interest in interests)
            {
                foreach (var person in interest.Persons)
                {
                    if (person.PersonId == id)
                    {
                        result.Add(interest);
                    }
                }
            }
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"Person with id : {id} not found.");
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            try
            {
                if (person == null)
                {
                    return BadRequest();
                }
                var createdPerson = _personRepo.Add(person);
                return CreatedAtAction(nameof(Get), new { id = createdPerson.PersonId }, createdPerson);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was an error creating db entry.");
            }
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, Person person) 
        //{
        //    if (person.PersonId == id)
        //    {
        //        _personRepo.Update(person);
        //        return Ok(person);
        //    }
        //    return NotFound($"Person with Id {id} not found.");
        //}

        [HttpPut("{id:int}/{name}/{phone}")]
        public IActionResult UpdateNameAndPhone(int id, string name, string phone)
        {
            var result = _personRepo.GetById(id);
            if ( result != null)
            {
                Person updatedPerson = new Person { PersonId = id, Name = name, Phone = phone };
                _personRepo.Update(updatedPerson);
                return Ok(updatedPerson);
            }
            return NotFound($"Person with Id {id} not found.");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _personRepo.GetById(id);
            if (result != null)
            {
                _personRepo.Delete(result);
                return Ok(result);
            }
            return NotFound($"The person you are trying to delete does not exist.");
        }
    }
}
