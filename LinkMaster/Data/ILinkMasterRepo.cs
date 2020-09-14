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
        IEnumerable<Link> GetAllCommands();
        Link GetLinkById(int id);
        void CreateLink(Link cmd);
        void UpdateLink(Link cmd);
        void DeleteLink(Link cmd);
    }
}
