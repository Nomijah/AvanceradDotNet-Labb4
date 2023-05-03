using System.ComponentModel.DataAnnotations;

namespace AvanceradDotNet_Labb4.Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IEnumerable<Person> Persons { get; set; }
        public IEnumerable<Link> Links { get; set; }

        public Interest()
        {

        }
    }
}