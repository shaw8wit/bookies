using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bookies.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace bookies.ViewModel
{
    public class BookControllerAddBookViewModel
    {
        public int? Id { get; set; }

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

        public IList<Genre> Genres { get; set; }

        public IList<Author> Authors { get; set; }

        public void SetArtists(IEnumerable<Author> Author)
        {
            SelectedAuthors = new MultiSelectList(Author, "Id", "Name");
        }
        [Display(Name = "Authors")]
        public MultiSelectList SelectedAuthors { get; private set; }

        public void SetGenres(IEnumerable<Genre> Genre)
        {
            SelectedGenres = new MultiSelectList(Genre, "Id", "Name");
        }
        [Display(Name = "Genres")]
        public MultiSelectList SelectedGenres { get; private set; }
    }
}