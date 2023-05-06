using AvanceradDotNet_Labb4.Models;
using AvanceradDotNet_Labb4.Services;
using Microsoft.AspNetCore.Mvc;


namespace AvanceradDotNet_Labb4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private ILabb4<Link> _linkRepo;

        public LinkController(ILabb4<Link> linkRepo)
        {
            _linkRepo = linkRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_linkRepo.GetAll());
        }

        [HttpPost]
        public IActionResult Create(string title, string url, int personId, int interestId)
        {
            try
            {
                Link linkToCreate = new Link() { LinkName = title, LinkUrl = url,
                    PersonId = personId, InterestId = interestId };
                _linkRepo.Add(linkToCreate);
                return Ok(linkToCreate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
