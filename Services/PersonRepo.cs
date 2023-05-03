using AvanceradDotNet_Labb4.Data;
using AvanceradDotNet_Labb4.Models;
using System;

namespace AvanceradDotNet_Labb4.Services
{
    public class PersonRepo : ILabb4<Person>
    {
        private AppDbContext _appDbContext;

        public PersonRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Person Add(Person entity)
        {
            if (entity != null)
            {
                _appDbContext.Persons.Add(entity);
                _appDbContext.SaveChanges();
                return entity;
            }
            else
            {
                return null;
            }
        }

        public Person Delete(Person pToDelete)
        {
            var result = GetSingle(pToDelete.PersonId);
            if (result != null)
            {
                _appDbContext.Persons.Remove(result);
                _appDbContext.SaveChanges();
                return result;
            }
            return null;
        }

        public IEnumerable<Person> GetAll()
        {
            return _appDbContext.Persons;
        }

        public Person GetSingle(int id)
        {
            return _appDbContext.Persons.FirstOrDefault(p => p.PersonId == id);
        }

        public Person GetById(int id)
        {
            return _appDbContext.Persons.FirstOrDefault(p => p.PersonId == id);
        }

        public Person Update(Person entity)
        {
            var person = _appDbContext.Persons.FirstOrDefault(p => p.PersonId == entity.PersonId);
            if (person != null)
            {
                person.Name = entity.Name;
                person.Interests = entity.Interests;
                person.Phone = entity.Phone;
                person.Links = entity.Links;
                _appDbContext.SaveChanges();
                return person;
            }
            else
            {
                return null;
            }
        }
    }
}
