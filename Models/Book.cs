using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace bookies.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Isbn { get; set; }

        [Required]
        public int Price { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public ICollection<Author> Authors { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}