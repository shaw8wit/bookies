using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace bookies.Models
{
    public class Librarycard
    {
        public int LId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        [StringLength(20)]
        public string Subscriptiontype { get; set; }

        

        
    }
}