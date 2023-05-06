using AvanceradDotNet_Labb4.Data;
using AvanceradDotNet_Labb4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AvanceradDotNet_Labb4.Services
{
    public class InterestRepo : ILabb4<Interest>
    {
        private AppDbContext _appDbContext;

        public InterestRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Interest Add(Interest entity)
        {
            if (entity != null)
            {
                _appDbContext.Interests.Add(entity);
                _appDbContext.SaveChanges();
                return entity;
            }
            else
            {
                return null;
            }
        }

        public Interest Delete(Interest iToDelete)
        {
            var result = GetById(iToDelete.InterestId);
            if (result != null)
            {
                _appDbContext.Interests.Remove(result);
                _appDbContext.SaveChanges();
                return result;
            }
            return null;
        }

        public IEnumerable<Interest> GetAll()
        {
            return _appDbContext.Interests.Include(i => i.Persons);
        }

        public Interest GetById(int id)
        {
            return _appDbContext.Interests.FirstOrDefault(i => i.InterestId == id);
        }

        public Interest Update(Interest entity)
        {
            var interest = _appDbContext.Interests.FirstOrDefault(i => i.InterestId == entity.InterestId);
            if (interest != null)
            {
                interest.Title = entity.Title;
                interest.Description = entity.Description;
                interest.Persons = entity.Persons;
                interest.Links = entity.Links;
                _appDbContext.SaveChanges();
                return interest;
            }
            else
            {
                return null;
            }
        }
    }
}
