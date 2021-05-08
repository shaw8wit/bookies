using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bookies.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}