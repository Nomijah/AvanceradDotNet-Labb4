using AvanceradDotNet_Labb4.Models;
using AvanceradDotNet_Labb4.Services;
using Microsoft.AspNetCore.Mvc;


namespace AvanceradDotNet_Labb4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private PersonRepo _personRepo;
        public PersonController(PersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_personRepo.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var result = _personRepo.GetSingle(id);
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

        [HttpPut("{id}")]
        public IActionResult Update(int id, Person person) 
        {
            if (person.PersonId == id)
            {
                _personRepo.Update(person);
                return Ok(person);
            }
            return NotFound($"Person with Id {id} not found.");
        }

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
