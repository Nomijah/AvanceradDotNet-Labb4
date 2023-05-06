using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AvanceradDotNet_Labb4.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        [JsonIgnore]
        public ICollection<Interest>? Interests { get; set; }
        [JsonIgnore]
        public ICollection<Link>? Links { get; set; }

        public Person() { }
        public Person(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
    }
}
