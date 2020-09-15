using LinkMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMaster.Data
{
    public class SQLLinkRepo : ILinkMasterRepo
    {
        private readonly LinkMasterContext _context;
        public void CreateLink(Link lnk)
        {
            if (lnk == null)
            {
                throw new ArgumentNullException(nameof(lnk));
            }

            _context.LinkData.Add(lnk);
        }

        public void DeleteLink(Link lnk)
        {
            if (lnk == null)
            {
                throw new ArgumentNullException(nameof(lnk));
            }
            _context.LinkData.Remove(lnk);
        }

        public IEnumerable<Link> GetAllLinks()
        {
            return _context.LinkData.ToList();
        }

        public Link GetLinkById(int id)
        {
            return _context.LinkData.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateLink(Link lnk)
        {
            //Nothing
            throw new NotImplementedException();
        }
    }
}
