using LinkMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMaster.Data
{
    public interface ILinkMasterRepo
    {
        bool SaveChanges();
        IEnumerable<Link> GetAllLinks();
        Link GetLinkById(int id);
        void CreateLink(Link lnk);
        void UpdateLink(Link lnk);
        void DeleteLink(Link lnk);
    }
}
