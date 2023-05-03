using System.ComponentModel.DataAnnotations;

namespace AvanceradDotNet_Labb4.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public IEnumerable<Interest>? Interests { get; set; }
        public IEnumerable<Link>? Links { get; set; }

        public Person() { }
        public Person(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
    }
}
