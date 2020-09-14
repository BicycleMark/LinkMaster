using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMaster.Model
{
    public class Link
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public Uri Uri { get; set; }

        [Required]
        public string Category  { get; set; }
    }

    public class LinkAccount : Link
    {
        [Required]
        public string User { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
