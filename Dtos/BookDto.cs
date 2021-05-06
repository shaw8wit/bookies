using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bookies.Dtos;

namespace bookies.Dtos
{
    public class BookDto
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

        public ICollection<AuthorDto> Authors { get; set; }

        public ICollection<GenreDto> Genres { get; set; }
    }
}