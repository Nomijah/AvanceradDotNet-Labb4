using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AvanceradDotNet_Labb4.Models
{
    public class Interest
    {
        [Key]
        public int InterestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<Person> Persons { get; set; }
        [JsonIgnore]
        public ICollection<Link> Links { get; set; }

        public Interest()
        {

        }
    }
}