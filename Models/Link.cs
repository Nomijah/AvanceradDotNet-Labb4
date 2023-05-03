using System.ComponentModel.DataAnnotations;

namespace AvanceradDotNet_Labb4.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        public string LinkName { get; set; }
        public string LinkUrl { get; set; }
        public int? InterestId { get; set; }
        public Interest? Interest { get; set; }
        public int? PersonId { get; set; }
        public Person? Person { get; set; }

        public Link() 
        {

        }

    }
}