using AvanceradDotNet_Labb4.Models;
using AvanceradDotNet_Labb4.Services;
using Microsoft.AspNetCore.Mvc;


namespace AvanceradDotNet_Labb4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private ILabb4<Interest> _interestRepo;
        private ILabb4<Person> _personRepo;
        public InterestController(ILabb4<Interest> interestRepo, ILabb4<Person> personRepo)
        {
            _interestRepo = interestRepo;
            _personRepo = personRepo;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            Console.WriteLine("Hej från getall");
            return Ok(_interestRepo.GetAll());
        }

        [HttpPut("AddPerson")]
        public IActionResult UpdatePerson(int interestId, int personId)
        {
            try
            {

                var iToUpdate = _interestRepo.GetById(interestId);
                var pToAdd = _personRepo.GetById(personId);
                if (iToUpdate != null)
                {
                    iToUpdate.Persons = new List<Person>() { pToAdd };
                    _interestRepo.Update(iToUpdate);
                    return Ok(iToUpdate);
                }
                return NotFound($"Interest with id : {interestId} or person with id : {personId} not found.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
