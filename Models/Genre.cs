﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bookies.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}