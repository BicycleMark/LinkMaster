using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAuthorization.Model
{
    public class Link
    {   
        public int Id { get; set; }    
        public String Uri { get; set; }   
        public string Category { get; set; }
    }

    public class LinkAccount : Link
    {
        public string User { get; set; }  
        public string Password { get; set; }
    }
}
