using AvanceradDotNet_Labb4.Data;
using AvanceradDotNet_Labb4.Models;

namespace AvanceradDotNet_Labb4.Services
{
    public class LinkRepo : ILabb4<Link>
    {
        private AppDbContext _appDbContext;
        public LinkRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Link Add(Link entity)
        {
            if (entity != null)
            {
                _appDbContext.Links.Add(entity);
                _appDbContext.SaveChanges();
                return entity;
            }
            else
            {
                return null;
            }
        }

        public Link Delete(Link entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Link> GetAll()
        {
            return _appDbContext.Links;
        }

        public Link GetById(int id)
        {
            return _appDbContext.Links.FirstOrDefault(Li => Li.LinkId == id);
        }

        public Link Update(Link entity)
        {
            throw new NotImplementedException();
        }
    }
}
