using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AvanceradDotNet_Labb4.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        public string LinkName { get; set; }
        public string LinkUrl { get; set; }
        public int? InterestId { get; set; }
        [JsonIgnore]
        public Interest? Interest { get; set; }
        public int? PersonId { get; set; }
        [JsonIgnore]
        public Person? Person { get; set; }

        public Link() 
        {

        }

    }
}