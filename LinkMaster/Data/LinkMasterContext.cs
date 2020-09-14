using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LinkMaster.Model;

namespace LinkMaster.Data
{
    public class LinkMasterContext : DbContext
    {
        public LinkMasterContext (DbContextOptions<LinkMasterContext> options)
            : base(options)
        {
        }

        public DbSet<LinkMaster.Model.Link> LinkData { get; set; }
    }
}
